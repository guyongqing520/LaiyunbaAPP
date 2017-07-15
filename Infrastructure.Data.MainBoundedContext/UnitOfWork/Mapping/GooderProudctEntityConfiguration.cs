
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class GooderProudctEntityConfiguration
        : EntityTypeConfiguration<GooderProudct>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public GooderProudctEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            this.Property(c => c.AccountId)
                .IsRequired();

            this.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.Mobile)
             .HasMaxLength(50)
             .IsRequired();

            this.Property(c => c.CarLength)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.CarType)
                 .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.DestCityFrist)
                 .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.LayEndTime)
                .IsRequired();

            this.Property(c => c.LayStartTime)
                .IsRequired();

            this.Property(c => c.Payway)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.SourceCity)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.Transferway)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.DestCitySecond)
                .HasMaxLength(256);

            this.Property(c => c.DestCityThird)
               .HasMaxLength(256);

            this.Property(c => c.GooderVolume)
               .HasMaxLength(256);

            this.Property(c => c.GooderHeight)
               .HasMaxLength(256);

            this.Property(c => c.UnitPrice)
                .HasPrecision(10, 2)
                .IsRequired();


            this.Property(c => c.IsRefresh)
                .IsRequired();

            this.Property(c => c.Remark)
                .HasMaxLength(500);

            this.Property(c => c.IsEnabled)
                .IsRequired();

            //configure table map
            this.ToTable("GooderProudcts");
        }
    }
}
