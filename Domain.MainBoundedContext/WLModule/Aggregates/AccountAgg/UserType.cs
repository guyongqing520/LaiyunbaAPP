using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg
{
    public enum UserType
    {

        GoogUser = 0,
        CarUser = 1,
        Admin=2

    }
}
