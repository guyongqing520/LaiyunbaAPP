using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.OrderAgg
{
    public enum OrderState
    {

        Transiting = 0,
        Transited = 1,
        TransitCannel = 2
    }
}
