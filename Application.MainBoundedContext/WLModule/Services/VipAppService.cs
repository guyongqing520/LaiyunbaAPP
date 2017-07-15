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
using Domain.MainBoundedContext.WLModule.Aggregates.VipAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class VipAppService
        : IVipAppService
    {

        #region Members

        readonly IVipRepository _vipRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Praise Management Service
        /// </summary>
        /// <param name="vipRepository">Associated vipRepository, intented to be resolved with DI</param>
        public VipAppService(IVipRepository vipRepository) //the vip repository                   
        {

            if (vipRepository == null)
                throw new ArgumentNullException("vipRepository");

            _vipRepository = vipRepository;

        }


        #endregion


        #region PraiseRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="praiseDTO"></param>
        /// <returns></returns>
        public VipDTO AddNewVip(VipDTO vipDTO)
        {
            //check preconditions
            if (vipDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddVipWithEmptyInformation);

            //Create the entity and the required associated data
            var vip = VipFactory.CreateVip(vipDTO.CreateOn, vipDTO.EndDateTime, vipDTO.AccountId, vipDTO.Remark);

            //save entity
            SaveVip(vip);

            //return the data with id and assigned default values
            return vip.ProjectedAs<VipDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<VipDTO> FindVips(int pageIndex, int pageCount, Guid AccountId, out long total)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindSmss);

            //recover praise
            var vips = _vipRepository.GetPaged(pageIndex, pageCount, c=>c.AccountId==AccountId ,c => c.CreateOn, false,out total);

            if (vips != null
                &&
                vips.Any())
            {
                return vips.ProjectedAsCollection<VipDTO>();
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
        public VipDTO FindVip(Guid accountId)
        {
            //recover existing favoriteId and map
            var vip = _vipRepository.Get(accountId);

            if (vip != null) //adapt
            {
                return vip.ProjectedAs<VipDTO>();
            }
            else
                return null;
        }


        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="smsDTO"></param>
        public void UpdateVip(VipDTO vipDTO)
        {
            if (vipDTO == null || vipDTO.Id == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotUpdateVipWithEmptyInformation);

            //get persisted item
            var persisted = _vipRepository.Get(vipDTO.Id);

            if (persisted != null) //if customer exist
            {
                //materialize from customer dto
                var current = MaterializeVipFromDto(vipDTO);

                //Merge changes
                _vipRepository.Merge(persisted, current);

                //commit unit of work
                _vipRepository.UnitOfWork.Commit();
            }
            else
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingVIP);
        }


        #endregion

        #region Private Methods

        Vip MaterializeVipFromDto(VipDTO vipDTO)
        {

            var current = VipFactory.CreateVip(vipDTO.CreateOn, vipDTO.EndDateTime, vipDTO.AccountId, vipDTO.Remark);

            current.ChangeCurrentIdentity(vipDTO.Id);

            return current;
        }

        void SaveVip(Vip vip)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(vip)) //if favorite is valid
            {
                //add the favorite into the repository
                _vipRepository.Add(vip);

                //commit the unit of work
                _vipRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Vip>(vip));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _vipRepository.Dispose();
        }

        #endregion

    }
}
