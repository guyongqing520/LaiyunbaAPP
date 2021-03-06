﻿
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg;

namespace Infrastructure.Data.MainBoundedContext.WLModule.Repositories
{
    /// <summary>
    /// The customer repository implementation
    /// </summary>
    public class DriverWayRepository
        : Repository<DriverWay>, IDriverWayRepository
    {

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public DriverWayRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region ICustomerRepository Members


        #endregion
    }
}
