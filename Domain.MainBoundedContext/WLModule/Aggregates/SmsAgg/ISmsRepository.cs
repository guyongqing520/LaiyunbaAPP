
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg
{
    public interface ISmsRepository : IRepository<Sms>
    {
        Sms Get(string mobile, string code, int validateState);
        Sms Get(string mobile);
    }
}
