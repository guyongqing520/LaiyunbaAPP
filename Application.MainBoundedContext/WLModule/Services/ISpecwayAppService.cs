using Application.MainBoundedContext.DTO;
using Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface ISpecwayAppService : IDisposable
    {

         /// <summary>
        /// news a account
        /// </summary>
        /// <param name="favoriteDTO"></param>
        /// <returns></returns>
        SpecwayDTO AddNewSpecway(SpecwayDTO specwayDTO);

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<SpecwayDTO> FindSpecways<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<Specway, bool>> filter, System.Linq.Expressions.Expression<Func<Specway, KProperty>> orderByExpression, bool ascending,out long total);

        /// <summary>
        /// find user info
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <param name="specwayId"></param>
        /// <returns></returns>
        SpecwayDTO FindSpecway(Guid id);

        /// <summary>
        /// update a user info
        /// </summary>
        /// <param name="smsDTO"></param>
        void UpdateSpecway(SpecwayDTO specwayDTO);

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        void RemoveSpecway(Guid id);

    }
}
