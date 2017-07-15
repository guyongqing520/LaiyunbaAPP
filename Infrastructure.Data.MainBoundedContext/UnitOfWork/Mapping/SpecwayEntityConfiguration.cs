using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg;


namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class SpecwayEntityConfiguration
        : EntityTypeConfiguration<Specway>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public SpecwayEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            this.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.SourcePrivince)
                .IsRequired();

            this.Property(c => c.SourceCity)
                .IsRequired();

            this.Property(c => c.DestCity)
                .IsRequired();

            this.Property(c => c.ViewCount)
                .IsRequired();

            this.Property(c => c.IsEnabled)
                .IsRequired();


            //configure table map
            this.ToTable("Specials");
        }
    }
}
