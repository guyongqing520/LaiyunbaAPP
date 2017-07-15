
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.VipAgg;

namespace Infrastructure.Data.MainBoundedContext.WLModule.Repositories
{
    /// <summary>
    /// The customer repository implementation
    /// </summary>
    public class VipRepository
        : Repository<Vip>, IVipRepository
    {

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public VipRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region ICustomerRepository Members

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg.ICustomerRepository"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Vip Get(Guid accountId)
        {
            if (accountId != Guid.Empty)
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                var set = currentUnitOfWork.CreateSet<Vip>();

                return set.Where(c => c.AccountId == accountId)
                          .SingleOrDefault();
            }
            else
                return null;
        }

        #endregion
    }
}
