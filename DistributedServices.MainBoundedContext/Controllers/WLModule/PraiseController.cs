using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.WLModule.Services;
using System;

using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("praise")]
    public class PraiseController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members


        readonly IPraiseAppService _praiseAppService;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        public PraiseController(IPraiseAppService praiseAppService)
        {
            if (praiseAppService == null)
                throw new ArgumentNullException("praiseAppService");

            this._praiseAppService = praiseAppService;

        }

        #endregion


        // GET: api/call
        public IHttpActionResult Post([FromBody] PraiseDTO praise)
        {

            if (praise.AccountId == Guid.Empty || praise.SpecwayId == Guid.Empty)
                throw new ArgumentNullException("praiseAppService");

            var rpraDTO = _praiseAppService.FindPraise(praise.SpecwayId, praise.AccountId);

            if (rpraDTO == null || rpraDTO.Id == Guid.Empty)
            {
                var praDTO = _praiseAppService.AddNewPraise(new Application.MainBoundedContext.DTO.PraiseDTO()
                {
                    AccountId = praise.AccountId,
                    CreateOn = DateTime.Now,
                    SpecwayId = praise.SpecwayId
                });
            }
            else
                _praiseAppService.RemovePraiseDTO(rpraDTO.Id);

            return Ok();
        }
    }
}


