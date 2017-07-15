
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg;

namespace Infrastructure.Data.MainBoundedContext.WLModule.Repositories
{
    /// <summary>
    /// The customer repository implementation
    /// </summary>
    public class ProudctRepository
        : Repository<GooderProudct>, IProudctRepository
    {

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public ProudctRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region IProudctRepository Members

        #endregion
    }
}
