using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.MainBoundedContext.Resources;
using DistributedServices.Seedwork;
using DistributedServices.Seedwork.Regex;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using System;
using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("register")]
    public class RegisterController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IAccountAppService _accountAppService;
        readonly ISmsAppService _smsAppService;
        readonly IVipAppService _vipAppService;
        readonly IMsgAppService _msgAppService;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="accountAppService"></param>
        /// <param name="smsAppService"></param>
        /// <param name="msgAppService"></param>
        /// <param name="vipAppService"></param>
        public RegisterController(IAccountAppService accountAppService, ISmsAppService smsAppService, IVipAppService vipAppService, IMsgAppService msgAppService)
        {
            if (accountAppService == null)
                throw new ArgumentNullException("accountAppService");

            if (smsAppService == null)
                throw new ArgumentNullException("smsAppService");

            if (vipAppService == null)
                throw new ArgumentNullException("vipAppService");

            if (msgAppService == null)
                throw new ArgumentNullException("msgAppService");

            this._accountAppService = accountAppService;
            this._smsAppService = smsAppService;
            this._vipAppService = vipAppService;
            this._msgAppService = msgAppService;
        }

        #endregion


        // POST: account/register
        /// <summary>
        /// {"UserName","1381604888404","UserType":"0","Pwd","124875445","HeadUrl",""}
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Post(RegisterViewModel register)
        {

            if (!Pool<MobileRegex>.Instance.IsMatch(register.UserName))
                return Ok<string>(Messages.error_ValidateMobileFormat);

            if (register.Password.Length < 6 || register.Password.Length > 32)
                return Ok<string>(Messages.error_ValidateMobileOrPasswordFormat);

            //修改验证码状态
            var smsDTO = this._smsAppService.FindSms(register.UserName, register.SmsCode, 0);

            if (smsDTO == null || (DateTime.Now - smsDTO.CreateDate).TotalHours > 1)
                return Ok<string>(Messages.error_ValidateSmsFormat);

            if (this._accountAppService.FindAccount(register.UserName) != null)
                return Ok<string>(Messages.error_ValidateMobileReisterExisting);

            smsDTO.ValidateState = 1;

            this._smsAppService.UpdateSms(smsDTO);


            var accountDTO = new Application.MainBoundedContext.DTO.AccountDTO() { Mobile = register.UserName, UserType = register.UserType, PassWord = register.Password, CreateTime = DateTime.Now, IsEnabled = true };


            if (register.UserType.Equals(UserType.GoogUser.ToString()))

                accountDTO.GooderAuthInfo_HeadUrl = register.HeadUrl;

            else
                accountDTO.DriverAuthInfo_HeadUrl = register.HeadUrl;


            var resultAccountDTO = this._accountAppService.AddNewAccount(accountDTO);

            if (resultAccountDTO == null)
                throw new NotImplementedException();

            //vip信息
            var resultVipDTO = this._vipAppService.AddNewVip(new Application.MainBoundedContext.DTO.VipDTO() { AccountId = resultAccountDTO.Id, CreateOn = DateTime.Now, EndDateTime = DateTime.Now.AddYears(1) });

            //加入动态展示
            this._msgAppService.AddNewMsg(new Application.MainBoundedContext.DTO.MsgDTO() { MsType = "注册", Context = "会员加入来运吧" });

            return Json<dynamic>(new { data = new { userinfo = resultAccountDTO, vipinfo = resultVipDTO }, total = 1 });
        }
    }


    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SmsCode { get; set; }
        public int UserType { get; set; }
        public string HeadUrl { get; set; }
    }
}

