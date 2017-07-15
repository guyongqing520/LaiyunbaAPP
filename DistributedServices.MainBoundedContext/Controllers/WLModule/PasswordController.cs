using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.MainBoundedContext.Resources;
using DistributedServices.Seedwork;
using DistributedServices.Seedwork.Regex;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using System;
using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("password")]
    public class PasswordController : ApiController
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
        public PasswordController(IAccountAppService accountAppService, ISmsAppService smsAppService, IVipAppService vipAppService)
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


        // POST: account/register
        /// <summary>
        /// {"UserName","1381604888404","UserType":"0","Pwd","124875445","HeadUrl",""}
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Post(PasswordViewModel value)
        {

            if (value.Action== "ForgotPwd")
            {

                if (!Pool<MobileRegex>.Instance.IsMatch(value.Mobile))
                    return Ok<string>(Messages.error_ValidateMobileFormat);

                if (value.Password.Length > 32||value.Password.Length < 6)
                     return Ok<string>(Messages.error_ValidatePasswordFormat);
              
                else if (String.Compare(value.Password, value.ConfirmPassword) != 0)
                    return Ok<string>(Messages.error_ValidatePasswordAndConfirmPasswordFormat);
                

                //修改验证码状态
                var smsDTO = this._smsAppService.FindSms(value.Mobile, value.SmsCode, 0);

                if (smsDTO == null || (DateTime.Now - smsDTO.CreateDate).TotalHours > 1)
                    return Ok<string>(Messages.error_ValidateSmsFormat);

                var accountDTO = this._accountAppService.FindAccount(value.Mobile);

                if (accountDTO == null)
                    return Ok<string>(Messages.error_ValidateMobileNotReisterExisting);

                if (!accountDTO.IsEnabled)
                    return Ok<string>(Messages.error_ValidateMobileFreeze);

                if (accountDTO.PassWord.CompareTo(value.Password) == 0)
                    return Ok<string>(Messages.error_ValidatePasswordAndNewPasswordIsEq);

                accountDTO.PassWord = value.Password;

                _accountAppService.UpdateAccount(accountDTO);

                smsDTO.ValidateState = 1;

                this._smsAppService.UpdateSms(smsDTO);

                var resultVipDTO = this._vipAppService.FindVip(accountDTO.Id);

                return Json<dynamic>(new { data = new { userinfo = accountDTO, vipinfo = resultVipDTO }, total = 1 });
            }
            else if (value.Action == "ModifyPwd")
            {
                if (!Pool<MobileRegex>.Instance.IsMatch(value.Mobile))
                    return Ok<string>(Messages.error_ValidateMobileFormat);

                if (value.Password.Length > 32 || value.Password.Length < 6)
                    return Ok<string>(Messages.error_ValidatePasswordFormat);

                else if (String.Compare(value.NewPassword, value.ConfirmPassword) != 0)
                    return Ok<string>(Messages.error_ValidatePasswordAndNewPasswordNotEq);

                var accountDTO = this._accountAppService.FindAccount(value.Mobile);

                if (accountDTO == null)
                    return Ok<string>(Messages.error_ValidateMobileNotReisterExisting);

                if (!accountDTO.IsEnabled)
                    return Ok<string>(Messages.error_ValidateMobileFreeze);

                if (accountDTO.PassWord.CompareTo(value.NewPassword) == 0)
                    return Ok<string>(Messages.error_ValidatePasswordAndNewPasswordIsEq);

                accountDTO.PassWord = value.NewPassword;

                _accountAppService.UpdateAccount(accountDTO);

                var resultVipDTO = this._vipAppService.FindVip(accountDTO.Id);

                return Json<dynamic>(new { data = new { userinfo = accountDTO, vipinfo = resultVipDTO }, total = 1 });

            }
            else if (value.Action == "ModifyMobile")
            {
                if (!Pool<MobileRegex>.Instance.IsMatch(value.Mobile))
                    return Ok<string>(Messages.error_ValidateMobileFormat);

                if (!Pool<MobileRegex>.Instance.IsMatch(value.NewMobile))
                    return Ok<string>(Messages.error_ValidateNewMobileFormat);

                var accountDTO = this._accountAppService.FindAccount(value.Mobile);

                if (accountDTO == null)
                    return Ok<string>(Messages.error_ValidateMobileNotReisterExisting);

                if (!accountDTO.IsEnabled)
                    return Ok<string>(Messages.error_ValidateMobileFreeze);

                if (accountDTO.Mobile.CompareTo(value.NewMobile) == 0)
                    return Ok<string>(Messages.error_ValidateNewMobileAndMobileIsEq);

                if (this._accountAppService.FindAccount(value.NewMobile) != null)
                    return Ok<string>(Messages.error_ValidateNewMobileReisterExisting);

                accountDTO.Mobile = value.NewMobile;

                _accountAppService.UpdateAccount(accountDTO);

                var resultVipDTO = this._vipAppService.FindVip(accountDTO.Id);

                return Json<dynamic>(new { data = new { userinfo = accountDTO, vipinfo = resultVipDTO }, total = 1 });

            }
            throw new ArgumentNullException();
        }
    }


    public class PasswordViewModel
    {
        public string Action { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string NewMobile { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string SmsCode { get; set; }
    }

}

