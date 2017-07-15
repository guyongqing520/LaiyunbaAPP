using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.WLModule.Services;
using System;

using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("favorite")]
    public class FavoriteController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IFavoriteAppService _favoriteAppService;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        public FavoriteController(IFavoriteAppService favoriteAppService)
        {
            if (favoriteAppService == null)
                throw new ArgumentNullException("favoriteAppService");

            this._favoriteAppService = favoriteAppService;

        }

        #endregion

        // GET: api/call
        public IHttpActionResult Get(Guid accountId, int pageIndex, int pageCount)
        {
            if (accountId == Guid.Empty || pageIndex == 0 || pageCount < 1)
                throw new ArgumentNullException();

            long total = 0;
            var favorites = _favoriteAppService.FindFavorites(pageIndex, pageCount, accountId, out total);

            if (favorites == null)
                return NotFound();

            return Json<dynamic>(new { data = favorites, total = total });
        }

        // GET: api/call
        public IHttpActionResult Post([FromBody] FavoriteDTO favorite)
        {
            if (favorite.AccountId == Guid.Empty || favorite.SpecwayId == Guid.Empty)
                throw new ArgumentNullException();

            var rfavDTO = _favoriteAppService.FindFavorite(favorite.SpecwayId, favorite.AccountId);

            if (rfavDTO == null || rfavDTO.Id == Guid.Empty)
            {
                var favoriteDTO = _favoriteAppService.AddNewFavorite(new Application.MainBoundedContext.DTO.FavoriteDTO()
                {
                    AccountId = favorite.AccountId,
                    SpecwayId = favorite.SpecwayId,
                    CreateOn = DateTime.Now
                });
            }
            else
                _favoriteAppService.RemoveFavoriteDTO(rfavDTO.Id);

            return Ok();
        }
    }
}



