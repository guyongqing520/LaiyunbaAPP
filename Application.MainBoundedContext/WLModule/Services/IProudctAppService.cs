using Application.MainBoundedContext.DTO;
using Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface IProudctAppService : IDisposable
    {
        GooderProudctDTO AddNewProudct(GooderProudctDTO proudctDTO);
        List<GooderProudctDTO> FindGooderProudct(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<GooderProudct, bool>> filter, System.Linq.Expressions.Expression<Func<GooderProudct, bool>> orderByExpression, bool ascending);
        void UpdateProudct(GooderProudctDTO proudctDTO);
        void RemoveProudct(Guid proudctId);
        GooderProudctDTO FindProudct(Guid proudctId);
        List<GooderProudctDTO> FindGooderProudcts(int pageIndex, int pageCount, Guid accountId);



    }
}
