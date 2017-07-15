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
using Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class SpecwayAppService
        : ISpecwayAppService
    {

        #region Members

        readonly ISpecwayRepository _specwayRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Specway Management Service
        /// </summary>
        /// <param name="vipRepository">Associated specwayRepository, intented to be resolved with DI</param>
        public SpecwayAppService(ISpecwayRepository specwayRepository) //the vip repository                   
        {

            if (specwayRepository == null)
                throw new ArgumentNullException("specwayRepository");

            _specwayRepository = specwayRepository;

        }


        #endregion


        #region SpecwayRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="praiseDTO"></param>
        /// <returns></returns>
        public SpecwayDTO AddNewSpecway(SpecwayDTO specwayDTO)
        {
            //check preconditions
            if (specwayDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddSpecwayWithEmptyInformation);

            //Create the entity and the required associated data
            var specway = SpecwayFactory.CreateSpecway(specwayDTO.AccountId, specwayDTO.Name, specwayDTO.SourcePrivince, specwayDTO.SourceCity,
            specwayDTO.SourceArea, specwayDTO.SourceAddress, specwayDTO.SourceTelehone, specwayDTO.SourceMobile, specwayDTO.DestCity, specwayDTO.DestCity1,
            specwayDTO.DestCity2, specwayDTO.DestCity3, specwayDTO.HeadUrl, specwayDTO.CardPositiveUrl, specwayDTO.CardnegativeUrl, specwayDTO.BusinessUrl,
            specwayDTO.Remark, specwayDTO.ViewCount, specwayDTO.SceneUrl1, specwayDTO.SceneUrl2, specwayDTO.SceneUrl3, specwayDTO.SceneUrl4, specwayDTO.SceneUrl5, specwayDTO.SceneUrl6, specwayDTO.SceneUrl7, specwayDTO.SceneUrl8, specwayDTO.SceneUrl9, specwayDTO.SceneUrl10, specwayDTO.SceneUrl11, specwayDTO.SceneUrl12, specwayDTO.SceneUrl13, specwayDTO.SceneUrl14, specwayDTO.SceneUrl15, specwayDTO.SceneUrl16, specwayDTO.SceneUrl17, specwayDTO.SceneUrl18, specwayDTO.Lng, specwayDTO.Lat
            );

            //save entity
            SaveSpecway(specway);

            //return the data with id and assigned default values
            return specway.ProjectedAs<SpecwayDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.ISpecwayManagement.FindSpecways"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ISpecwayManagement.FindSpecways"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ISpecwayManagement.FindSpecways"/></param>
        /// <param name="filter"> <see cref="Application.MainBoundedContext.Services.ISpecwayManagement.FindSpecways"/></param>
        /// <param name="orderByExpression"> <see cref="Application.MainBoundedContext.Services.ISpecwayManagement.FindSpecways"/></param>
        /// <param name="ascending"> <see cref="Application.MainBoundedContext.Services.ISpecwayManagement.FindSpecways"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ISpecwayManagement.FindSpecwayes"/></returns>
        public List<SpecwayDTO> FindSpecways<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<Specway, bool>> filter, System.Linq.Expressions.Expression<Func<Specway, KProperty>> orderByExpression, bool ascending, out long total)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindSpecways);

            //recover praise
            var specways = _specwayRepository.GetPaged(pageIndex, pageCount, filter, orderByExpression, false,out total);

            if (specways != null
                &&
                specways.Any())
            {
                return specways.ProjectedAsCollection<SpecwayDTO>();
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
        public SpecwayDTO FindSpecway(Guid id)
        {
            //recover existing favoriteId and map
            var specway = _specwayRepository.Get(id);

            if (specway != null) //adapt
            {
                return specway.ProjectedAs<SpecwayDTO>();
            }
            else
                return null;
        }


        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="specwayDTO"></param>
        public void UpdateSpecway(SpecwayDTO specwayDTO)
        {
            if (specwayDTO == null || specwayDTO.Id == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotUpdateSpecwayWithEmptyInformation);

            //get persisted item
            var persisted = _specwayRepository.Get(specwayDTO.Id);

            if (persisted != null) //if customer exist
            {
                //materialize from customer dto
                var current = MaterializeSpecwayFromDto(specwayDTO);

                //Merge changes
                _specwayRepository.Merge(persisted, current);

                //commit unit of work
                _specwayRepository.UnitOfWork.Commit();
            }
            else
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotUpdateNonExistingSpecway);
        }



        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveSpecway(Guid id)
        {
            var specway = _specwayRepository.Get(id);

            if (specway != null) //if customer exist
            {
                //disable account "delete"
                specway.Disable();

                //commit changes
                _specwayRepository.UnitOfWork.Commit();
            }
            else //the customer not exist, cannot remove
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingCustomer);
        }


        #endregion

        #region Private Methods

        Specway MaterializeSpecwayFromDto(SpecwayDTO specwayDTO)
        {

            var current = SpecwayFactory.CreateSpecway(specwayDTO.AccountId, specwayDTO.Name, specwayDTO.SourcePrivince, specwayDTO.SourceCity,
            specwayDTO.SourceArea, specwayDTO.SourceAddress, specwayDTO.SourceTelehone, specwayDTO.SourceMobile, specwayDTO.DestCity, specwayDTO.DestCity1,
            specwayDTO.DestCity2, specwayDTO.DestCity3, specwayDTO.HeadUrl, specwayDTO.CardPositiveUrl, specwayDTO.CardnegativeUrl, specwayDTO.BusinessUrl,
            specwayDTO.Remark, specwayDTO.ViewCount, specwayDTO.SceneUrl1, specwayDTO.SceneUrl2, specwayDTO.SceneUrl3, specwayDTO.SceneUrl4, specwayDTO.SceneUrl5, specwayDTO.SceneUrl6, specwayDTO.SceneUrl7, specwayDTO.SceneUrl8, specwayDTO.SceneUrl9, specwayDTO.SceneUrl10, specwayDTO.SceneUrl11, specwayDTO.SceneUrl12, specwayDTO.SceneUrl13, specwayDTO.SceneUrl14, specwayDTO.SceneUrl15, specwayDTO.SceneUrl16, specwayDTO.SceneUrl17, specwayDTO.SceneUrl18, specwayDTO.Lng, specwayDTO.Lat
            );

            current.ChangeCurrentIdentity(current.Id);

            return current;
        }

        void SaveSpecway(Specway specway)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(specway)) //if favorite is valid
            {
                //add the favorite into the repository
                _specwayRepository.Add(specway);

                //commit the unit of work
                _specwayRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Specway>(specway));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _specwayRepository.Dispose();
        }

        #endregion

    }
}
