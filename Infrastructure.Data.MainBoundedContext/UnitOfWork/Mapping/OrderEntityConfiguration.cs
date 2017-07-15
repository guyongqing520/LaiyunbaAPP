
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.MainBoundedContext.WLModule.Aggregates.OrderAgg;

namespace Infrastructure.Data.MainBoundedContext.UnitOfWork.Mapping
{
    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class OrderEntityConfiguration
        : EntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public OrderEntityConfiguration()
        {
            //configure key and properties

            #region order of info


            this.HasKey(c => c.Id);

            this.Property(c => c.OrderNo)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.DriverDownOrderPrice)
                .HasPrecision(10, 2)
                .IsRequired();

            this.Property(c => c.GooderName)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.SourceCity)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.DestCityFrist)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.DestCitySecond)
                .HasMaxLength(256);

            this.Property(c => c.DestCityThird)
                .HasMaxLength(256);

            this.Property(c => c.CarLength)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.CarType)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.GooderVolume)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.GooderHeight)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.LayStartTime)
                .IsRequired();

            this.Property(c => c.LayEndTime)
                .IsRequired();

            this.Property(c => c.UnitPrice)
                .HasPrecision(10, 2)
                .IsRequired();

            this.Property(c => c.Transferway)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.Payway)
                .HasMaxLength(256)
                .IsRequired();

            this.Property(c => c.Remark)
                .HasMaxLength(500);

            this.Property(c => c.RefundRreason)
                .HasMaxLength(500);

            this.Property(c => c.CancelRreason)
                .HasMaxLength(500);

            this.Property(c => c.OrderState)
                .IsRequired();

            this.Property(c => c.OrderState)
                .IsRequired();

            this.Property(c => c.IsRefund)
                .IsRequired();

            this.Property(c => c.IsEnabled)
                .IsRequired();

            #endregion

            #region gooder of info

            this.Property(c => c.GooderAccountId)
                .IsRequired();

            this.Property(c => c.GooderMobile)
                .HasMaxLength(25)
                .IsRequired();

            this.Property(c => c.GooderInfo.RealName)
                .HasMaxLength(256)
                .HasColumnName("GooderRealName");

            this.Property(c => c.GooderInfo.CardNo)
                .HasMaxLength(256)
                .HasColumnName("GooderCardNo");

            this.Property(c => c.GooderInfo.HeadUrl)
                .HasMaxLength(256)
                .HasColumnName("GooderHeadUrl");

            this.Property(c => c.GooderInfo.CardNoUrl)
                .HasMaxLength(256)
                .HasColumnName("GooderCardNoUrl");

            this.Property(c => c.GooderInfo.ComparyName)
                .HasMaxLength(256)
                .HasColumnName("GooderComparyName");

            this.Property(c => c.GooderInfo.ComparyCity)
                .HasMaxLength(256)
                .HasColumnName("GooderComparyCity");

            this.Property(c => c.GooderInfo.ComparyAddress)
                .HasMaxLength(256)
                .HasColumnName("GooderComparyAddress");


            this.Property(c => c.GooderInfo.BusinesslicenseUrl)
                .HasMaxLength(256)
                .HasColumnName("GooderBusinesslicenseUrl");

            //this.Ignore(c => c.GooderInfo.IsEnabled);

            #endregion

            #region driverr of info

            this.Property(c => c.DriverAccountId)
                .IsRequired();

            this.Property(c => c.DriverMobile)
                .HasMaxLength(25)
                .IsRequired();

            this.Property(c => c.DriverInfo.RealName)
                .HasMaxLength(256)
                .HasColumnName("DriverRealName");

            this.Property(c => c.DriverInfo.CardNo)
                .HasMaxLength(256)
                .HasColumnName("DriverCardNo");

            this.Property(c => c.DriverInfo.HeadUrl)
                .HasMaxLength(256)
                .HasColumnName("DriverHeadUrl");

            this.Property(c => c.DriverInfo.CarNo)
                .HasMaxLength(256)
                .HasColumnName("DriverCarNo");

            this.Property(c => c.DriverInfo.CarType)
                .HasMaxLength(256)
                .HasColumnName("DriverCarType");

            this.Property(c => c.DriverInfo.CarLength)
                .HasMaxLength(256)
                .HasColumnName("DriverCarLength");

            this.Property(c => c.DriverInfo.CarHeight)
                .HasMaxLength(256)
                .HasColumnName("DriverCarHeight");

            this.Property(c => c.DriverInfo.CarBrand)
                .HasMaxLength(256)
                .HasColumnName("DriverCarBrand");

            this.Property(c => c.DriverInfo.CarYear)
                .HasMaxLength(256)
                .HasColumnName("DriverCarYear");

            this.Property(c => c.DriverInfo.DriverLicenceUrl)
                .HasMaxLength(256)
                .HasColumnName("DriverLicenceUrl");

            this.Property(c => c.DriverInfo.CarVehicleUrl)
                .HasMaxLength(256)
                .HasColumnName("DriverCarVehicleUrl");

            //this.Ignore(c => c.DriverInfo.IsEnabled);

            #endregion

            #region gooder of location info


            this.Property(c => c.GooderLocation.Lat)
                .HasColumnName("GooderLat");

            this.Property(c => c.GooderLocation.Lng)
                .HasColumnName("GooderLng");

            //this.Ignore(c => c.GooderLocation.LocationUpdateTime);
                

            //this.Property(c => c.GooderLocation.Location)
            //.HasColumnName("GooderLocation");

            #endregion

            //configure table map
            this.ToTable("Orders");
        }
    }
}
