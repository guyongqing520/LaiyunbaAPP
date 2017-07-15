using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.MainBoundedContext.Resources;
using DistributedServices.Seedwork;
using DistributedServices.Seedwork.Regex;
using DistributedServices.Seedwork.Sms;
using DistributedServices.Seedwork.Utils;
using System;
using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("sms")]
    public class SmsController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IAccountAppService _accountAppService;
        readonly ISmsAppService _smsAppService;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="accountAppService"></param>
        /// <param name="smsAppService"></param>
        public SmsController(IAccountAppService accountAppService, ISmsAppService smsAppService)
        {
            if (accountAppService == null)
                throw new ArgumentNullException("accountAppService");

            if (smsAppService == null)
                throw new ArgumentNullException("smsAppService");

            this._accountAppService = accountAppService;
            this._smsAppService = smsAppService;

        }


        public IHttpActionResult Get(Guid id, int pageIndex, int pageSize)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var accountDTO = _accountAppService.FindAccount(id);

            if (accountDTO.UserType != 2)
                return Ok<string>(Messages.error_ValidateNotAdmin);

            var smss = _smsAppService.FindSmss(pageIndex, pageSize);

            if (smss == null)
                return NotFound();

            return Json<dynamic>(new { data = smss, total = smss.Count });
        }

        public IHttpActionResult Post(SmsViewModel value)
        {

            if (!Pool<MobileRegex>.Instance.IsMatch(value.UserName))
                return Ok<string>(Messages.error_ValidateMobileFormat);

            var accountDTO = this._accountAppService.FindAccount(value.UserName);

            if (value.Action == "Login" || value.Action == "ForgotPwd" || value.Action == "ModifyMobile")
            {
                if (accountDTO == null)
                    return Ok<string>(Messages.error_ValidateMobileNotReisterExisting);

                if (!accountDTO.IsEnabled)
                    return Ok<string>(Messages.error_ValidateMobileFreeze);

            }
            else if (value.Action == "Register")
            {
                if (accountDTO != null)
                    return Ok<string>(Messages.error_ValidateMobileReisterExisting);
            }
            else
            {
                throw new ArgumentNullException();
            }

            SmsDTO smsDTO = this._smsAppService.FindSms(value.UserName);

            if (smsDTO != null && (DateTime.Now - smsDTO.CreateDate).TotalMinutes < 1)
                return Ok<string>(Messages.error_ValidateSmsTimeCount);


            var smsCode = CharHelper.GetRandomSmsCode(6);


            //向指定的用户发送短信
            var codeTag = value.Action== "Login" ? 30351 : value.Action== "ModifyPwd" ? 8412 : value.Action == "ModifyMobile" ? 8413 : 8411;


            CodeSms codeSms = new DistributedServices.Seedwork.Sms.CodeSms(value.UserName, codeTag, string.Format("#app#={0}&#code#={0}&#hour#={0}", "来运吧物流", smsCode, 1));
            SmsSendServer.SendSmsResult result = codeSms.Send();

            if (result.ToString().Equals("Fail"))
                return Ok<string>(codeSms.ErrorMsg);

            var ip = UrlHelper.GetClientIP();

            var resultSmsDTO = this._smsAppService.AddNewSms(new Application.MainBoundedContext.DTO.SmsDTO()
            {
                Code = smsCode,
                CreateDate = DateTime.Now,
                IP = ip,
                Mobile = value.UserName,
                ValidateState = 0,
                Type = value.SmsType
            });

            return Json<dynamic>(new { data = resultSmsDTO, total = 1 });
        }
    }

    public class SmsViewModel
    {
        public string UserName { get; set; }
        public string Action { get; set; }
        public string SmsType { get; set; }
    }

        #endregion

}


