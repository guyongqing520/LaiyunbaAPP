using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class DriverWayEntityConfiguration
        : EntityTypeConfiguration<DriverWay>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public DriverWayEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            this.Property(c => c.AccountId)
                .IsRequired();

            this.Property(c => c.DestCity)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.SourceCity)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.IsEnabled)
                .IsRequired();

            //configure table map
            this.ToTable("DriverWays");
        }
    }
}
