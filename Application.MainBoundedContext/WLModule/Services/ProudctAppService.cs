using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.Resources;
using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Seedwork;
using Infrastructure.Crosscutting.Validator;
using Infrastructure.Crosscutting.Logging;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg;
using System.Transactions;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class ProudctAppService
        : IProudctAppService
    {

        #region Members

        readonly IProudctRepository _proudctRepository;
        readonly IAccountRepository _accountRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Customer Management Service
        /// </summary>
        /// <param name="accountRepository">Associated CustomerRepository, intented to be resolved with DI</param>
        public ProudctAppService(IProudctRepository proudctRepository, IAccountRepository accountRepository) //the userinfo repository                   
        {

            if (proudctRepository == null)
                throw new ArgumentNullException("proudctRepository");

            if (accountRepository == null)
                throw new ArgumentNullException("accountRepository");

            _proudctRepository = proudctRepository;
            _accountRepository = accountRepository;

        }

        #endregion


        #region IAccountAppService Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <returns></returns>
        public GooderProudctDTO AddNewProudct(GooderProudctDTO proudctDTO)
        {
            //check preconditions
            if (proudctDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddGooderProudctWithEmptyInformation);

            var account = _accountRepository.Get(proudctDTO.AccountId);

            if (account != null)
            {
                var product = GooderProudctFactory.CreateGooderProudct(proudctDTO.AccountId,
                    proudctDTO.Name, proudctDTO.SourceCity, proudctDTO.DestCityFrist, proudctDTO.DestCitySecond,
                    proudctDTO.DestCityThird, proudctDTO.CarLength, proudctDTO.CarType, proudctDTO.GooderVolume,
                    proudctDTO.GooderHeight, proudctDTO.LayStartTime, proudctDTO.LayEndTime, proudctDTO.UnitPrice,
                    proudctDTO.Transferway, proudctDTO.Payway, proudctDTO.Remark, proudctDTO.IsRefresh,
                    proudctDTO.Lat, proudctDTO.Lng);

                //save entity
                SaveProdect(product, account);

                //return the data with id and assigned default values
                return product.ProjectedAs<GooderProudctDTO>();
            }
            else
                return null;
        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<GooderProudctDTO> FindGooderProudct(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<GooderProudct, bool>> filter, System.Linq.Expressions.Expression<Func<GooderProudct, bool>> orderByExpression, bool ascending)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindGooderProudcts);

            long total = 0;

            //recover praise
            var gooderProudcts = _proudctRepository.GetPaged(pageIndex, pageCount, filter, orderByExpression, false,out total);

            if (gooderProudcts != null
                &&
                gooderProudcts.Any())
            {
                return gooderProudcts.ProjectedAsCollection<GooderProudctDTO>();
            }
            else // no data.
                return null;
        }



        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="customerDTO"></param>
        public void UpdateProudct(GooderProudctDTO proudctDTO)
        {
            if (proudctDTO == null || proudctDTO.Id == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotUpdateProudctWithEmptyInformation);

            //get persisted item
            var persisted = _proudctRepository.Get(proudctDTO.Id);

            if (persisted != null) //if customer exist
            {
                //materialize from customer dto
                var current = MaterializeAccountFromDto(proudctDTO);

                //Merge changes
                _proudctRepository.Merge(persisted, current);

                //commit unit of work
                _proudctRepository.UnitOfWork.Commit();
            }
            else
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingProudct);
        }

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveProudct(Guid proudctId)
        {
            var proudct = _proudctRepository.Get(proudctId);

            if (proudct != null) //if proudct exist
            {
                //disable proudct "delete"
                proudct.Disable();

                //commit changes
                _proudctRepository.UnitOfWork.Commit();
            }
            else //the customer not exist, cannot remove
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingProudct);
        }

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public GooderProudctDTO FindProudct(Guid proudctId)
        {
            //recover existing account and map
            var proudct = _proudctRepository.Get(proudctId);

            if (proudct != null) //adapt
            {
                return proudct.ProjectedAs<GooderProudctDTO>();
            }
            else
                return null;
        }


        /// <summary>
        ///  <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<GooderProudctDTO> FindGooderProudcts(int pageIndex, int pageCount, Guid accountId)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindProudcts);

            long total = 0;
            //recover countries
            var proudcts = _proudctRepository.GetPaged(pageIndex, pageCount, c => c.AccountId == accountId && c.IsEnabled, c => c.CreateTime, false,out total);

            if (proudcts != null
                &&
                proudcts.Any())
            {
                return proudcts.ProjectedAsCollection<GooderProudctDTO>();
            }
            else // no data.
                return null;

        }


        #endregion

        #region Private Methods


        GooderProudct MaterializeAccountFromDto(GooderProudctDTO proudctDTO)
        {

            var current = GooderProudctFactory.CreateGooderProudct(proudctDTO.AccountId,
                    proudctDTO.Name, proudctDTO.SourceCity, proudctDTO.DestCityFrist, proudctDTO.DestCitySecond,
                    proudctDTO.DestCityThird, proudctDTO.CarLength, proudctDTO.CarType, proudctDTO.GooderVolume,
                    proudctDTO.GooderHeight, proudctDTO.LayStartTime, proudctDTO.LayEndTime, proudctDTO.UnitPrice,
                    proudctDTO.Transferway, proudctDTO.Payway, proudctDTO.Remark, proudctDTO.IsRefresh,
                    proudctDTO.Lat, proudctDTO.Lng);


            current.ChangeCurrentIdentity(proudctDTO.Id);


            return current;
        }


        void SaveProdect(GooderProudct proudct, Account account)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(proudct)) //if customer is valid
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    //add the proudct into the repository
                    _proudctRepository.Add(proudct);

                    account.ChangeTransactionNumber(account.TransactionNumber + 1);
                    //commit changes

                    _proudctRepository.UnitOfWork.Commit();
                    _accountRepository.UnitOfWork.Commit();

                    //complete transaction
                    scope.Complete();
                }
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<GooderProudct>(proudct));
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
