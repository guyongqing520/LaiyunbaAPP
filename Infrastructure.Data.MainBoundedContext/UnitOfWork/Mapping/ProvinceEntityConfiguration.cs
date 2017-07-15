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
    class ProvinceEntityConfiguration
        : EntityTypeConfiguration<Province>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public ProvinceEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.id);

            this.Property(c => c.provinceID)
                .IsOptional();

            this.Property(c => c.province)
                .HasColumnType("varchar")
                .HasMaxLength(40);

            //configure table map
            this.ToTable("Provinces");
        }
    }
}
