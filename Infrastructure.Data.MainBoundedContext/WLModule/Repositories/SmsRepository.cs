
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg;

namespace Infrastructure.Data.MainBoundedContext.WLModule.Repositories
{
    /// <summary>
    /// The customer repository implementation
    /// </summary>
    public class SmsRepository
        : Repository<Sms>, ISmsRepository
    {

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public SmsRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region IProudctRepository Members


        public Sms Get(string mobile)
        {
            if (!string.IsNullOrEmpty(mobile))
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                var set = currentUnitOfWork.CreateSet<Sms>();

                return set.Where(c => c.Mobile.Equals(mobile)).OrderByDescending(c => c.CreateDate)
                          .SingleOrDefault();
            }
            else
                return null;
        }

        public Sms Get(string mobile, string code, int validateState)
        {
            if (!string.IsNullOrEmpty(mobile) && !string.IsNullOrEmpty(code))
            {
                var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

                var set = currentUnitOfWork.CreateSet<Sms>();

                return set.Where(c => c.Mobile.Equals(mobile) && c.Code.Equals(code) && (c.ValidateState == validateState)).OrderByDescending(c=>c.CreateDate)
                          .SingleOrDefault();
            }
            else
                return null;
        }


        #endregion
    }
}
