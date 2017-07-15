using Application.MainBoundedContext.WLModule.Services;
using System;
using DistributedServices.Seedwork;
using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("call")]
    public class CallController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members


        readonly ICallLogAppService _callAppService;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="accountAppService"></param>
        /// <param name="smsAppService"></param>
        /// <param name="msgAppService"></param>
        /// <param name="vipAppService"></param>
        public CallController(ICallLogAppService callAppService)
        {
            if (callAppService == null)
                throw new ArgumentNullException("callAppService");

            this._callAppService = callAppService;

        }

        #endregion

        // GET: api/call
        public IHttpActionResult Get(Guid accountId, int pageIndex, int pageCount)
        {
            if (accountId == Guid.Empty || pageIndex == 0 || pageCount < 1)
                throw new ArgumentNullException();

            long total = 0;

            var calllogs = _callAppService.FindCallLogs(pageIndex, pageCount, accountId, out total);

            if (calllogs == null)
                return NotFound();

            return Json<dynamic>(new { data = calllogs, total = total });
        }

        // GET: api/call
        public IHttpActionResult Post(CallLogViewModel value)
        {
            var callDTO = _callAppService.AddNewCallLog(new Application.MainBoundedContext.DTO.CallLogDTO()
            {
                CreateOn = DateTime.Now,
                DestAccountId = value.DestAccountId,
                SourceAccountId = value.SourceAccountId,
                GooderProudctId = value.GooderProudctId,
                SpecwayId = value.SpecwayId,
                UserType = value.UserType
            });
            return Ok();
        }

        // DELETE: api/call
        public IHttpActionResult Delete(Guid id)
        {

            if (id == Guid.Empty)
                throw new ArgumentNullException();
     
            _callAppService.RemoveCallLog(id);

            return Ok();

        }
    }

    public class CallLogViewModel
    {
        public Guid DestAccountId { get; set; }
        public Guid SourceAccountId { get; set; }

        public Guid GooderProudctId { get; set; }
        public Guid SpecwayId { get; set; }
        public int UserType { get; set; }

    }
}


