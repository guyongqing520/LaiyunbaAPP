using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface ISmsAppService : IDisposable
    {

         /// <summary>
        /// news a account
        /// </summary>
        /// <param name="favoriteDTO"></param>
        /// <returns></returns>
        SmsDTO AddNewSms(SmsDTO smsDTO);

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<SmsDTO> FindSmss(int pageIndex, int pageCount);


        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        SmsDTO FindSms(string mobile);

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <param name="specwayId"></param>
        /// <returns></returns>
        SmsDTO FindSms(string mobile, string code, int validateState);

        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="smsDTO"></param>
        void UpdateSms(SmsDTO smsDTO);


    }
}
