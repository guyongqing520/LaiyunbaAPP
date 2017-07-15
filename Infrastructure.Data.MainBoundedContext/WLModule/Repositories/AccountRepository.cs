
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;

namespace Infrastructure.Data.MainBoundedContext.WLModule.Repositories
{
    /// <summary>
    /// The customer repository implementation
    /// </summary>
    public class AccountRepository
        : Repository<Account>, IAccountRepository
    {

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public AccountRepository(MainBCUnitOfWork unitOfWork)
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
        public override Account Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                var set = currentUnitOfWork.CreateSet<Account>();

                return set.Where(c => c.Id == id)
                          .SingleOrDefault();
            }
            else
                return null;
        }


        public Account Get(string mobile)
        {
            if (!string.IsNullOrEmpty(mobile))
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                var set = currentUnitOfWork.CreateSet<Account>();

                return set.Where(c => c.Mobile == mobile)
                          .SingleOrDefault();
            }
            else
                return null;
        }

        public Account Get(string mobile, string password, bool enable)
        {
            if (!string.IsNullOrEmpty(mobile))
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                var set = currentUnitOfWork.CreateSet<Account>();

                return set.Where(c => c.Mobile.Equals(mobile) && c.PassWord.Equals(password) && (c.IsEnabled == enable))
                          .SingleOrDefault();
            }
            else
                return null;
        }


        #endregion
    }
}
