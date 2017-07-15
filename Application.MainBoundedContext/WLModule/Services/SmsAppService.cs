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
using Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class SmsAppService:
        ISmsAppService
    {

        #region Members

        readonly ISmsRepository _smsRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Praise Management Service
        /// </summary>
        /// <param name="favoriteRepository">Associated smsRepository, intented to be resolved with DI</param>
        public SmsAppService(ISmsRepository smsRepository) //the userinfo repository                   
        {

            if (smsRepository == null)
                throw new ArgumentNullException("smsRepository");

            _smsRepository = smsRepository;

        }


        #endregion


        #region PraiseRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="praiseDTO"></param>
        /// <returns></returns>
        public SmsDTO AddNewSms(SmsDTO smsDTO)
        {
            //check preconditions
            if (smsDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddSmsWithEmptyInformation);

            //Create the entity and the required associated data
            var sms = SmsFactory.CreateSms(smsDTO.Code, smsDTO.Mobile, smsDTO.Type, smsDTO.IP, smsDTO.ValidateState);

            //save entity
            SaveSms(sms);

            //return the data with id and assigned default values
            return sms.ProjectedAs<SmsDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<SmsDTO> FindSmss(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindSmss);

            //recover praise
            var smss = _smsRepository.GetPaged(pageIndex, pageCount, c => c.CreateDate, false);

            if (smss != null
                &&
                smss.Any())
            {
                return smss.ProjectedAsCollection<SmsDTO>();
            }
            else // no data.
                return null;
        }


        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="praiseId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public SmsDTO FindSms(string mobile, string code, int validateState)
        {
            //recover existing favoriteId and map
            var sms = _smsRepository.Get(mobile, code, validateState);

            if (sms != null) //adapt
            {
                return sms.ProjectedAs<SmsDTO>();
            }
            else
                return null;
        }

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="praiseId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public SmsDTO FindSms(string mobile)
        {
            //recover existing favoriteId and map
            var sms = _smsRepository.Get(mobile);

            if (sms != null) //adapt
            {
                return sms.ProjectedAs<SmsDTO>();
            }
            else
                return null;
        }


        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="smsDTO"></param>
        public void UpdateSms(SmsDTO smsDTO)
        {
            if (smsDTO == null || smsDTO.Id == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotUpdateSmsWithEmptyInformation);

            //get persisted item
            var persisted = _smsRepository.Get(smsDTO.Id);

            if (persisted != null) //if customer exist
            {
                //materialize from customer dto
                var current = MaterializeSmsFromDto(smsDTO);

                //Merge changes
                _smsRepository.Merge(persisted, current);

                //commit unit of work
                _smsRepository.UnitOfWork.Commit();
            }
            else
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingSms);
        }
  

        #endregion

        #region Private Methods

        Sms MaterializeSmsFromDto(SmsDTO smsDTO)
        {

            var current = SmsFactory.CreateSms(smsDTO.Code, smsDTO.Mobile, smsDTO.Type, smsDTO.IP, smsDTO.ValidateState);

            current.ChangeCurrentIdentity(smsDTO.Id);


            return current;
        }

        void SaveSms(Sms sms)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(sms)) //if favorite is valid
            {
                //add the favorite into the repository
                _smsRepository.Add(sms);

                //commit the unit of work
                _smsRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Sms>(sms));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _smsRepository.Dispose();
        }

        #endregion

    }
}
