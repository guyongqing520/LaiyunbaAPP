using Application.MainBoundedContext.WLModule.Services;
using System;
using System.Collections.Generic;

using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("message")]
    public class MsgController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IMsgAppService _msgAppService;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="msgAppService"></param>
        public MsgController(IMsgAppService msgAppService)
        {
            if (msgAppService == null)
                throw new ArgumentNullException("msgAppService");

            this._msgAppService = msgAppService;

        }

        #endregion

        // GET: api/message
        public IHttpActionResult Get()
        {
            var msgs = this._msgAppService.FindMsgs(0, 50);
            if (msgs == null)
                return NotFound();

            return Json<dynamic>(new { data = msgs, total = 50 });
        }
    }
}

