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
using Domain.MainBoundedContext.WLModule.Aggregates.CallLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class CallLogAppService
        : ICallLogAppService
    {

        #region Members

        readonly ICallLogRepository _callLogRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Customer Management Service
        /// </summary>
        /// <param name="accountRepository">Associated CustomerRepository, intented to be resolved with DI</param>
        public CallLogAppService(ICallLogRepository callLogRepository) //the userinfo repository                   
        {

            if (callLogRepository == null)
                throw new ArgumentNullException("callLogRepository");

            _callLogRepository = callLogRepository;

        }


        #endregion


        #region ICallLogRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="callLogDTO"></param>
        /// <returns></returns>
        public CallLogDTO AddNewCallLog(CallLogDTO callLogDTO)
        {
            //check preconditions
            if (callLogDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddCallLogWithEmptyInformation);

            //Create the entity and the required associated data
            var calllog = CallLogFactory.CreateCallLog(callLogDTO.SpecwayId, callLogDTO.GooderProudctId, callLogDTO.SourceAccountId, (UserType)callLogDTO.UserType, callLogDTO.DestAccountId, callLogDTO.Message);

            //save entity
            SaveCallLog(calllog);

            //return the data with id and assigned default values
            return calllog.ProjectedAs<CallLogDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<CallLogDTO> FindCallLogs(int pageIndex, int pageCount, Guid? sourceAccountId,out long total)
        {
 
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindCallLogs);

            total = 0;

            //recover countries
            var callLogs = _callLogRepository.GetPaged(pageIndex, pageCount, c => c.SourceAccountId == sourceAccountId || c.DestAccountId == sourceAccountId, c => c.CreateOn, false,out total);

            if (callLogs != null
                &&
                callLogs.Any())
            {
                return callLogs.ProjectedAsCollection<CallLogDTO>();
            }
            else // no data.
                return null;
        }

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveCallLog(Guid id)
        {
            if (id == Guid.Empty)
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingCallLog);
            else
            {
                var calllog = _callLogRepository.Get(id);

                if (calllog != null) //if customer exist
                {
                    var deleteCallLog = new CallLog();
                    deleteCallLog.ChangeCurrentIdentity(id);

                    //disable account "delete"
                    _callLogRepository.Remove(deleteCallLog);

                    //commit changes
                    _callLogRepository.UnitOfWork.Commit();
                }
                else //the customer not exist, cannot remove
                    LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingCallLog);
            }
        }

        #endregion

        #region Private Methods



        void SaveCallLog(CallLog calllog)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(calllog)) //if customer is valid
            {
                //add the customer into the repository
                _callLogRepository.Add(calllog);

                //commit the unit of work
                _callLogRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<CallLog>(calllog));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _callLogRepository.Dispose();
        }

        #endregion

    }
}
