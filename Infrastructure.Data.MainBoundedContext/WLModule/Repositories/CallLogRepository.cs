
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.CallLogAgg;

namespace Infrastructure.Data.MainBoundedContext.WLModule.Repositories
{
    /// <summary>
    /// The customer repository implementation
    /// </summary>
    public class CallLogRepository
        : Repository<CallLog>, ICallLogRepository
    {

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public CallLogRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region IProudctRepository Members

        #endregion
    }
}
