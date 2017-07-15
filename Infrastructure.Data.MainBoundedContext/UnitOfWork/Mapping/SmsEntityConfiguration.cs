using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg;


namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class SmsEntityConfiguration
        : EntityTypeConfiguration<Sms>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public SmsEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            this.Property(c => c.Code)
                .HasMaxLength(6)
                .IsRequired();


            this.Property(c => c.ValidateState)
                .IsRequired();


            //configure table map
            this.ToTable("SmsValidates");
        }
    }
}
