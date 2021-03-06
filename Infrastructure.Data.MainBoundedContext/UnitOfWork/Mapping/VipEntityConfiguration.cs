﻿using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.VipAgg;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class VipEntityConfiguration
        : EntityTypeConfiguration<Vip>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public VipEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            //configure table map
            this.ToTable("Vips");
        }
    }
}
