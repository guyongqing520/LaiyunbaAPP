
using Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg
{
    public interface ILoginLogRepository : IRepository<LoginLog>
    {

    }
}
