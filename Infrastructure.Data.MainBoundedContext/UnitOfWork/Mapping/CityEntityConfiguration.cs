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
    class CityEntityConfiguration
        : EntityTypeConfiguration<City>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public CityEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.id);

            this.Property(c => c.cityID)
                .IsOptional();

            this.Property(c => c.city)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            this.Property(c => c.father)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            //configure table map
            this.ToTable("Citys");
        }
    }
}
