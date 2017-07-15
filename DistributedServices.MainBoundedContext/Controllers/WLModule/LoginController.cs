using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.MainBoundedContext.Resources;
using DistributedServices.Seedwork;
using DistributedServices.Seedwork.Regex;
using System;
using System.Net;
using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IAccountAppService _accountAppService;
        readonly ISmsAppService _smsAppService;
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
        public LoginController(IAccountAppService accountAppService, ISmsAppService smsAppService, IVipAppService vipAppService)
        {
            if (accountAppService == null)
                throw new ArgumentNullException("accountAppService");

            if (smsAppService == null)
                throw new ArgumentNullException("smsAppService");

            if (vipAppService == null)
                throw new ArgumentNullException("vipAppService");

            this._accountAppService = accountAppService;
            this._smsAppService = smsAppService;
            this._vipAppService = vipAppService;
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/login
        public IHttpActionResult Post([FromBody] LoginViewModel login)
        {

            if (login.Action == "Mobile")//params username,password,action
            {
                if (!Pool<MobileRegex>.Instance.IsMatch(login.UserName))
                    return Ok<string>(Messages.error_ValidateMobileFormat);

                if (login.Password.Length < 6 || login.Password.Length > 32)
                    return Ok<string>(Messages.error_ValidateMobileOrPasswordFormat);

                var resultAccountDTO = this._accountAppService.FindAccount(login.UserName, login.Password, true);

                if (resultAccountDTO == null || resultAccountDTO.Id == Guid.Empty)
                    return Ok<string>(Messages.error_ValidateMobileOrPasswordFormat);

                var resultVipDTO = this._vipAppService.FindVip(resultAccountDTO.Id);

                return Json<dynamic>(new { data = new { userinfo = resultAccountDTO, vipinfo = resultVipDTO }, total = 1 });

            }
            else if (login.Action == "Sms") //params username,sms,action
            {
                if (!Pool<MobileRegex>.Instance.IsMatch(login.UserName))
                    return Ok<string>(Messages.error_ValidateMobileFormat);

                if (login.Sms.Length != 6)
                    return Ok<string>(Messages.error_ValidateSmsFormat);

                var resultAccountDTO = this._accountAppService.FindAccount(login.UserName);

                if (resultAccountDTO == null || resultAccountDTO.Id == Guid.Empty)
                    return Ok<string>(Messages.error_ValidateMobileNotReisterExisting);

                if (!resultAccountDTO.IsEnabled)
                    return Ok<string>(Messages.error_ValidateMobileFreeze);


                var smsDTO = this._smsAppService.FindSms(login.UserName, login.Sms, 0);

                if (smsDTO == null || smsDTO.Id == Guid.Empty || (DateTime.Now - smsDTO.CreateDate).TotalHours > 1)
                    return Ok<string>(Messages.error_ValidateSmsFormat);

                smsDTO.ValidateState = 1;

                this._smsAppService.UpdateSms(smsDTO);

                var resultVipDTO = this._vipAppService.FindVip(resultAccountDTO.Id);

                return Json<dynamic>(new { data = new { userinfo = resultAccountDTO, vipinfo = resultVipDTO }, total = 1 });
            }

            throw new ArgumentNullException();
        }
    }


    public class LoginViewModel
    {
        public string Action { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public string Sms { get; set; }
    }

}

