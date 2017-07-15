using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface IFavoriteAppService : IDisposable
    {

         /// <summary>
        /// news a account
        /// </summary>
        /// <param name="favoriteDTO"></param>
        /// <returns></returns>
        FavoriteDTO AddNewFavorite(FavoriteDTO favoriteDTO);

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<FavoriteDTO> FindFavorites(int pageIndex, int pageCount, Guid accountId,out long total);

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <param name="specwayId"></param>
        /// <returns></returns>
        FavoriteDTO FindFavorite(Guid favoriteId,Guid accountId);

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        void RemoveFavoriteDTO(Guid id);
    }
}
