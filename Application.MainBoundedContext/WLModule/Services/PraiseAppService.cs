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
using Domain.MainBoundedContext.WLModule.Aggregates.PraiseAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class PraiseAppService 
        : IPraiseAppService
    {

        #region Members

        readonly IPraiseRepository _praiseRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Praise Management Service
        /// </summary>
        /// <param name="favoriteRepository">Associated praiseRepository, intented to be resolved with DI</param>
        public PraiseAppService(IPraiseRepository praiseRepository) //the userinfo repository                   
        {

            if (praiseRepository == null)
                throw new ArgumentNullException("praiseRepository");

            _praiseRepository = praiseRepository;

        }


        #endregion


        #region PraiseRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="praiseDTO"></param>
        /// <returns></returns>
        public PraiseDTO AddNewPraise(PraiseDTO praiseDTO)
        {
            //check preconditions
            if (praiseDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddPraiseWithEmptyInformation);

            //Create the entity and the required associated data
            var praise = PraiseFactory.CreatePraise(praiseDTO.AccountId, praiseDTO.SpecwayId);

            //save entity
            SavePraise(praise);

            //return the data with id and assigned default values
            return praise.ProjectedAs<PraiseDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<PraiseDTO> FindPraises(int pageIndex, int pageCount, Guid accountId)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindFavorites);

            long total=0;
            //recover praise
            var praises = _praiseRepository.GetPaged(pageIndex, pageCount, c => c.AccountId == accountId, c => c.CreateOn, false, out total);

            if (praises != null
                &&
                praises.Any())
            {
                return praises.ProjectedAsCollection<PraiseDTO>();
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
        public PraiseDTO FindPraise(Guid praiseId, Guid accountId)
        {
            //recover existing favoriteId and map
            var praise = _praiseRepository.Get(praiseId, accountId);

            if (praise != null) //adapt
            {
                return praise.ProjectedAs<PraiseDTO>();
            }
            else
                return null;
        }


        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="Id"></param>
        public void RemovePraiseDTO(Guid id)
        {
            if (id == Guid.Empty)
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingPraise);
            else
            {
                var praise = _praiseRepository.Get(id);

                var deletePraise = new Praise();
                deletePraise.ChangeCurrentIdentity(id);

                //disable account "delete"
                _praiseRepository.Remove(deletePraise);

                //commit changes
                _praiseRepository.UnitOfWork.Commit();

            }
        }

        #endregion

        #region Private Methods



        void SavePraise(Praise praise)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(praise)) //if favorite is valid
            {
                //add the favorite into the repository
                _praiseRepository.Add(praise);

                //commit the unit of work
                _praiseRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Praise>(praise));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _praiseRepository.Dispose();
        }

        #endregion

    }
}
