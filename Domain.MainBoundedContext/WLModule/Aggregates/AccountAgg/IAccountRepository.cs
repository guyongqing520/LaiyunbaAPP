using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account Get(string mobile);
        Account Get(string mobile, string password, bool enable);
    }
}
