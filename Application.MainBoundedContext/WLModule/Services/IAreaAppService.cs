using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface IAreaAppService : IDisposable
    {


        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<AreaDTO> FindAreas(string city);
    }
}
