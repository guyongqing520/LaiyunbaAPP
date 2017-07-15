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
using Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class LoginLogAppService
        : ILoginLogAppService
    {

        #region Members

        readonly ILoginLogRepository _loginLogRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Praise Management Service
        /// </summary>
        /// <param name="vipRepository">Associated vipRepository, intented to be resolved with DI</param>
        public LoginLogAppService(ILoginLogRepository loginLogRepository) //the vip repository                   
        {

            if (loginLogRepository == null)
                throw new ArgumentNullException("loginLogRepository");

            _loginLogRepository = loginLogRepository;

        }


        #endregion


        #region loginLogRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="praiseDTO"></param>
        /// <returns></returns>
        public LoginLogDTO AddNewLoginLog(LoginLogDTO loginLogDTO)
        {
            //check preconditions
            if (loginLogDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddVipWithEmptyInformation);

            //Create the entity and the required associated data
            var loginLog = LoginLogFactory.CreateLoginLog(loginLogDTO.AccountId, loginLogDTO.LoginDate, loginLogDTO.PlatForm, loginLogDTO.IP, loginLogDTO.City);

            //save entity
            SaveLoginLog(loginLog);

            //return the data with id and assigned default values
            return loginLog.ProjectedAs<LoginLogDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<LoginLogDTO> FindLoginLogs(int pageIndex, int pageCount, Guid accountId)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindLoginLogs);

            long total = 0;

            //recover praise
            var loginLogs = _loginLogRepository.GetPaged(pageIndex, pageCount, c => c.AccountId == accountId, c => c.CreateDate, false, out total);

            if (loginLogs != null
                &&
                loginLogs.Any())
            {
                return loginLogs.ProjectedAsCollection<LoginLogDTO>();
            }
            else // no data.
                return null;
        }


        #endregion

        #region Private Methods


        void SaveLoginLog(LoginLog loginLog)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(loginLog)) //if favorite is valid
            {
                //add the favorite into the repository
                _loginLogRepository.Add(loginLog);

                //commit the unit of work
                _loginLogRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<LoginLog>(loginLog));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _loginLogRepository.Dispose();
        }

        #endregion

    }
}
