using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Seedwork;
using Infrastructure.Crosscutting.Validator;
using Infrastructure.Crosscutting.Logging;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using System.Data.Entity.Spatial;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class AccountAppService
        : IAccountAppService
    {

        #region Members

        readonly IAccountRepository _accountRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Customer Management Service
        /// </summary>
        /// <param name="accountRepository">Associated CustomerRepository, intented to be resolved with DI</param>
        public AccountAppService(IAccountRepository accountRepository) //the userinfo repository                   
        {

            if (accountRepository == null)
                throw new ArgumentNullException("accountRepository");

            _accountRepository = accountRepository;

        }


        #endregion


        #region IAccountAppService Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <returns></returns>
        public AccountDTO AddNewAccount(AccountDTO accountDTO)
        {
            //check preconditions
            if (accountDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddCustomerWithEmptyInformation);

            var user = _accountRepository.Get(accountDTO.Mobile);

            if (user == null)
            {

                //Create the entity and the required associated data
                var gooder = new GooderAuthInfo(accountDTO.GooderAuthInfo_RealName, accountDTO.GooderAuthInfo_CardNo, accountDTO.GooderAuthInfo_CardNoUrl, accountDTO.GooderAuthInfo_HeadUrl, accountDTO.GooderAuthInfo_ComparyName, accountDTO.GooderAuthInfo_ComparyCity, accountDTO.GooderAuthInfo_ComparyAddress, accountDTO.GooderAuthInfo_BusinesslicenseUrl);

                var driver = new DriverAuthInfo(accountDTO.DriverAuthInfo_RealName, accountDTO.DriverAuthInfo_CardNo, accountDTO.DriverAuthInfo_HeadUrl, accountDTO.DriverAuthInfo_CarType, accountDTO.DriverAuthInfo_CarLength, accountDTO.DriverAuthInfo_CarNo, accountDTO.DriverAuthInfo_CarHeight, accountDTO.DriverAuthInfo_CarBrand, accountDTO.DriverAuthInfo_CarYear, accountDTO.DriverAuthInfo_DriverLicenceUrl, accountDTO.DriverAuthInfo_CarVehicleUrl);

                var location = new Location(accountDTO.CarLocation_Lng, accountDTO.CarLocation_Lat, accountDTO.CarLocation_LocationUpdateTime);

                var account = AccountFactory.CreateAccount(accountDTO.Mobile, accountDTO.PassWord, (UserType)accountDTO.UserType, driver, gooder, location);

                //save entity
                SaveAccount(account);

                //return the data with id and assigned default values
                return account.ProjectedAs<AccountDTO>();
            }
            else
                return null;
        }


        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="customerDTO"></param>
        public void UpdateAccount(AccountDTO accountDTO)
        {
            if (accountDTO == null || accountDTO.Id == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotUpdateCustomerWithEmptyInformation);

            //get persisted item
            var persisted = _accountRepository.Get(accountDTO.Mobile);

            if (persisted != null) //if customer exist
            {
                //materialize from customer dto
                var current = MaterializeAccountFromDto(accountDTO);

                //Merge changes
                _accountRepository.Merge(persisted, current);

                //commit unit of work
                _accountRepository.UnitOfWork.Commit();
            }
            else
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingCustomer);
        }

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveAccount(Guid accountId)
        {
            var account = _accountRepository.Get(accountId);

            if (account != null) //if customer exist
            {
                //disable account "delete"
                account.Disable();

                //commit changes
                _accountRepository.UnitOfWork.Commit();
            }
            else //the customer not exist, cannot remove
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingCustomer);
        }


        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountDTO FindAccount(Guid accountId)
        {
            //recover existing account and map
            var account = _accountRepository.Get(accountId);

            if (account != null) //adapt
                return account.ProjectedAs<AccountDTO>();
            else
                return null;
        }


        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountDTO FindAccount(string mobile)
        {
            //recover existing account and map
            var account = _accountRepository.Get(mobile);

            if (account != null) //adapt
            {
                return account.ProjectedAs<AccountDTO>();
            }
            else
                return null;
        }

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountDTO FindAccount(string mobile, string password, bool enable)
        {
            //recover existing account and map
            var account = _accountRepository.Get(mobile, password, enable);

            if (account != null) //adapt
            {
                return account.ProjectedAs<AccountDTO>();
            }
            else
                return null;
        }



        #endregion

        #region Private Methods


        Account MaterializeAccountFromDto(AccountDTO accountDTO)
        {

            var gooder = new GooderAuthInfo(accountDTO.GooderAuthInfo_RealName, accountDTO.GooderAuthInfo_CardNo, accountDTO.GooderAuthInfo_CardNoUrl, accountDTO.GooderAuthInfo_HeadUrl, accountDTO.GooderAuthInfo_ComparyName, accountDTO.GooderAuthInfo_ComparyCity, accountDTO.GooderAuthInfo_ComparyAddress, accountDTO.GooderAuthInfo_BusinesslicenseUrl);

            var driver = new DriverAuthInfo(accountDTO.DriverAuthInfo_RealName, accountDTO.DriverAuthInfo_CardNo, accountDTO.DriverAuthInfo_HeadUrl, accountDTO.DriverAuthInfo_CarType, accountDTO.DriverAuthInfo_CarLength, accountDTO.DriverAuthInfo_CarNo, accountDTO.DriverAuthInfo_CarHeight, accountDTO.DriverAuthInfo_CarBrand, accountDTO.DriverAuthInfo_CarYear, accountDTO.DriverAuthInfo_DriverLicenceUrl, accountDTO.DriverAuthInfo_CarVehicleUrl);

            var location = new Location(accountDTO.CarLocation_Lng, accountDTO.CarLocation_Lat, accountDTO.CarLocation_LocationUpdateTime);

            var current = AccountFactory.CreateAccount(accountDTO.Mobile, accountDTO.PassWord, (UserType)accountDTO.UserType, driver, gooder, location);

            current.ChangeCurrentIdentity(accountDTO.Id);


            return current;
        }


        void SaveAccount(Account account)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(account)) //if customer is valid
            {
                //add the customer into the repository
                _accountRepository.Add(account);

                //commit the unit of work
                _accountRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Account>(account));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _accountRepository.Dispose();
        }

        #endregion

    }
}
