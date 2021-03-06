﻿using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg;


namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class LoginLogEntityConfiguration
        : EntityTypeConfiguration<LoginLog>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public LoginLogEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            //configure table map
            this.ToTable("LoginLogs");
        }
    }
}
