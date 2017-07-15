
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.VipAgg
{
    public interface IVipRepository : IRepository<Vip>
    {
        Vip Get(Guid accountId);
    }
}
