using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface IPraiseAppService : IDisposable
    {

         /// <summary>
        /// news a account
        /// </summary>
        /// <param name="favoriteDTO"></param>
        /// <returns></returns>
        PraiseDTO AddNewPraise(PraiseDTO praiseDTO);

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<PraiseDTO> FindPraises(int pageIndex, int pageCount, Guid accountId);

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <param name="specwayId"></param>
        /// <returns></returns>
        PraiseDTO FindPraise(Guid praiseId, Guid accountId);

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        void RemovePraiseDTO(Guid id);
    }
}
