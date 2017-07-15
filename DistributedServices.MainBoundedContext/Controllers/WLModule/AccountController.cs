using Application.MainBoundedContext.WLModule.Services;
using System;
using System.Collections.Generic;

using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IAccountAppService _accountAppService;
        readonly ISmsAppService _smsAppService;
        readonly IMsgAppService _msgAppService;
        readonly IVipAppService _vipAppService;

        #endregion

        #region Constructors

  
        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="accountAppService"></param>
        /// <param name="smsAppService"></param>
        /// <param name="msgAppService"></param>
        /// <param name="vipAppService"></param>
        public AccountController(IAccountAppService accountAppService, ISmsAppService smsAppService, IMsgAppService msgAppService, IVipAppService vipAppService)
        {
            if (accountAppService == null)
                throw new ArgumentNullException("accountAppService");

            if (smsAppService == null)
                throw new ArgumentNullException("smsAppService");

            if (msgAppService == null)
                throw new ArgumentNullException("msgAppService");

            if (vipAppService == null)
                throw new ArgumentNullException("vipAppService");

            this._accountAppService = accountAppService;
            this._smsAppService = smsAppService;
            this._msgAppService = msgAppService;
            this._vipAppService = vipAppService;
        }

        #endregion

        // GET: api/Register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
    }
}

