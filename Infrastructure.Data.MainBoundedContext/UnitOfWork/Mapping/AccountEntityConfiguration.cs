using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class AccountEntityConfiguration
        : EntityTypeConfiguration<Account>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public AccountEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            this.Property(c => c.Mobile)
                .HasMaxLength(25)
                .IsRequired();

            this.Property(c => c.PassWord)
                .HasMaxLength(32)
                .IsRequired();

            this.Property(c => c.TransactionNumber)
                .IsRequired();

            this.Property(c => c.ShippedNumber)
                .IsRequired();

            this.Property(c => c.IsEnabled)
                .IsRequired();

            //configure table map
            this.ToTable("Accounts");
        }
    }
}
