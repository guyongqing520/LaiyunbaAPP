
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.FavoriteAgg
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        Favorite Get(Guid favoriteId, Guid accountId);
    }
}
