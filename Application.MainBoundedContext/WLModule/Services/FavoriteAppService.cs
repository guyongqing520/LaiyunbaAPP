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
using Domain.MainBoundedContext.WLModule.Aggregates.FavoriteAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class FavoriteAppService
        : IFavoriteAppService
    {

        #region Members

        readonly IFavoriteRepository _favoriteRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Favorite Management Service
        /// </summary>
        /// <param name="favoriteRepository">Associated favoriteRepository, intented to be resolved with DI</param>
        public FavoriteAppService(IFavoriteRepository favoriteRepository) //the userinfo repository                   
        {

            if (favoriteRepository == null)
                throw new ArgumentNullException("favoriteRepository");

            _favoriteRepository = favoriteRepository;

        }


        #endregion


        #region FavoriteRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="favoriteDTO"></param>
        /// <returns></returns>
        public FavoriteDTO AddNewFavorite(FavoriteDTO favoriteDTO)
        {
            //check preconditions
            if (favoriteDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddFavoriteWithEmptyInformation);

            //Create the entity and the required associated data
            var favorite = FavoriteFactory.CreateFavorite(favoriteDTO.AccountId, favoriteDTO.SpecwayId);

            //save entity
            SaveFavorite(favorite);

            //return the data with id and assigned default values
            return favorite.ProjectedAs<FavoriteDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<FavoriteDTO> FindFavorites(int pageIndex, int pageCount, Guid accountId, out long total)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindFavorites);

            //recover favorites
            var favorites = _favoriteRepository.GetPaged(pageIndex, pageCount, c => c.AccountId == accountId, c => c.CreateOn, false, out total);

            if (favorites != null
                &&
                favorites.Any())
            {
                return favorites.ProjectedAsCollection<FavoriteDTO>();
            }
            else // no data.
                return null;
        }


        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <param name="specwayId"></param>
        /// <returns></returns>
        public FavoriteDTO FindFavorite(Guid favoriteId, Guid accountId)
        {
            //recover existing favoriteId and map
            var favorite = _favoriteRepository.Get(favoriteId, accountId);

            if (favorite != null) //adapt
            {
                return favorite.ProjectedAs<FavoriteDTO>();
            }
            else
                return null;
        }


        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveFavoriteDTO(Guid id)
        {
            if (id == Guid.Empty)
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingFavorite);
            else
            {

                var deleteFavorite = new Favorite();
                deleteFavorite.ChangeCurrentIdentity(id);

                //disable account "delete"
                _favoriteRepository.Remove(deleteFavorite);

                //commit changes
                _favoriteRepository.UnitOfWork.Commit();

            }
        }

        #endregion

        #region Private Methods



        void SaveFavorite(Favorite favorite)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(favorite)) //if favorite is valid
            {
                //add the favorite into the repository
                _favoriteRepository.Add(favorite);

                //commit the unit of work
                _favoriteRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Favorite>(favorite));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _favoriteRepository.Dispose();
        }

        #endregion

    }
}
