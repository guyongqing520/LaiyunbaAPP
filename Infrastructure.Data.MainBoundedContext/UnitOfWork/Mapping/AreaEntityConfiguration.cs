using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.AddressAgg;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class AreaEntityConfiguration
        : EntityTypeConfiguration<Area>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public AreaEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.id);

            this.Property(c => c.areaID)
                .IsOptional();

            this.Property(c => c.area)
                .HasColumnType("varchar")
                .HasMaxLength(60);

            this.Property(c => c.father)
               .HasColumnType("varchar")
               .HasMaxLength(6);

            //configure table map
            this.ToTable("Areas");
        }
    }
}
