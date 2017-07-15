namespace Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Accounts", name: "GooderRealName", newName: "GooderAuthInfo_RealName");
            RenameColumn(table: "dbo.Accounts", name: "GooderCardNo", newName: "GooderAuthInfo_CardNo");
            RenameColumn(table: "dbo.Accounts", name: "GooderHeadUrl", newName: "GooderAuthInfo_HeadUrl");
            RenameColumn(table: "dbo.Accounts", name: "GooderCardNoUrl", newName: "GooderAuthInfo_CardNoUrl");
            RenameColumn(table: "dbo.Accounts", name: "GooderComparyName", newName: "GooderAuthInfo_ComparyName");
            RenameColumn(table: "dbo.Accounts", name: "GooderComparyCity", newName: "GooderAuthInfo_ComparyCity");
            RenameColumn(table: "dbo.Accounts", name: "GooderComparyAddress", newName: "GooderAuthInfo_ComparyAddress");
            RenameColumn(table: "dbo.Accounts", name: "GooderBusinesslicenseUrl", newName: "GooderAuthInfo_BusinesslicenseUrl");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthIsEnabled", newName: "GooderAuthInfo_IsEnabled");
            RenameColumn(table: "dbo.Accounts", name: "DriverRealName", newName: "DriverAuthInfo_RealName");
            RenameColumn(table: "dbo.Accounts", name: "DriverCardNo", newName: "DriverAuthInfo_CardNo");
            RenameColumn(table: "dbo.Accounts", name: "DriverHeadUrl", newName: "DriverAuthInfo_HeadUrl");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarNo", newName: "DriverAuthInfo_CarNo");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarType", newName: "DriverAuthInfo_CarType");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarLength", newName: "DriverAuthInfo_CarLength");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarHeight", newName: "DriverAuthInfo_CarHeight");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarBrand", newName: "DriverAuthInfo_CarBrand");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarYear", newName: "DriverAuthInfo_CarYear");
            RenameColumn(table: "dbo.Accounts", name: "DriverLicenceUrl", newName: "DriverAuthInfo_DriverLicenceUrl");
            RenameColumn(table: "dbo.Accounts", name: "DriverCarVehicleUrl", newName: "DriverAuthInfo_CarVehicleUrl");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthIsEnabled", newName: "DriverAuthInfo_IsEnabled");
            RenameColumn(table: "dbo.Accounts", name: "DrvierLng", newName: "CarLocation_Lng");
            RenameColumn(table: "dbo.Accounts", name: "DriverLat", newName: "CarLocation_Lat");
            RenameColumn(table: "dbo.Accounts", name: "DrvierLocation", newName: "CarLocation_Locations");
            RenameColumn(table: "dbo.Accounts", name: "DrvierLocationUpdateTime", newName: "CarLocation_LocationUpdateTime");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Accounts", name: "CarLocation_LocationUpdateTime", newName: "DrvierLocationUpdateTime");
            RenameColumn(table: "dbo.Accounts", name: "CarLocation_Locations", newName: "DrvierLocation");
            RenameColumn(table: "dbo.Accounts", name: "CarLocation_Lat", newName: "DriverLat");
            RenameColumn(table: "dbo.Accounts", name: "CarLocation_Lng", newName: "DrvierLng");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_IsEnabled", newName: "DriverAuthIsEnabled");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarVehicleUrl", newName: "DriverCarVehicleUrl");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_DriverLicenceUrl", newName: "DriverLicenceUrl");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarYear", newName: "DriverCarYear");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarBrand", newName: "DriverCarBrand");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarHeight", newName: "DriverCarHeight");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarLength", newName: "DriverCarLength");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarType", newName: "DriverCarType");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CarNo", newName: "DriverCarNo");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_HeadUrl", newName: "DriverHeadUrl");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_CardNo", newName: "DriverCardNo");
            RenameColumn(table: "dbo.Accounts", name: "DriverAuthInfo_RealName", newName: "DriverRealName");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_IsEnabled", newName: "GooderAuthIsEnabled");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_BusinesslicenseUrl", newName: "GooderBusinesslicenseUrl");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_ComparyAddress", newName: "GooderComparyAddress");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_ComparyCity", newName: "GooderComparyCity");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_ComparyName", newName: "GooderComparyName");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_CardNoUrl", newName: "GooderCardNoUrl");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_HeadUrl", newName: "GooderHeadUrl");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_CardNo", newName: "GooderCardNo");
            RenameColumn(table: "dbo.Accounts", name: "GooderAuthInfo_RealName", newName: "GooderRealName");
        }
    }
}
