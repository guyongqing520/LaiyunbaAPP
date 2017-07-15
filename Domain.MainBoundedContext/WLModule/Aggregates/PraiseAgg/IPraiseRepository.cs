
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.PraiseAgg
{
    public interface IPraiseRepository : IRepository<Praise>
    {
        Praise Get(Guid praiseId, Guid accountId);
    }
}
