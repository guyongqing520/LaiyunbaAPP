using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface IVipAppService : IDisposable
    {

         /// <summary>
        /// news a account
        /// </summary>
        /// <param name="favoriteDTO"></param>
        /// <returns></returns>
        VipDTO AddNewVip(VipDTO vipDTO);

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<VipDTO> FindVips(int pageIndex, int pageCount, Guid AccountId, out long total);

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <param name="specwayId"></param>
        /// <returns></returns>
        VipDTO FindVip(Guid accountId);

        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="smsDTO"></param>
        void UpdateVip(VipDTO vipDTO);


    }
}
