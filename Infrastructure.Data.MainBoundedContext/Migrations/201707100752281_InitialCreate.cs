namespace Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 25),
                        PassWord = c.String(nullable: false, maxLength: 32),
                        TransactionNumber = c.Int(nullable: false),
                        ShippedNumber = c.Int(nullable: false),
                        UserType = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        GooderRealName = c.String(maxLength: 256),
                        GooderCardNo = c.String(maxLength: 256),
                        GooderHeadUrl = c.String(maxLength: 256),
                        GooderCardNoUrl = c.String(maxLength: 256),
                        GooderComparyName = c.String(maxLength: 256),
                        GooderComparyCity = c.String(maxLength: 256),
                        GooderComparyAddress = c.String(maxLength: 256),
                        GooderBusinesslicenseUrl = c.String(maxLength: 256),
                        GooderAuthIsEnabled = c.Boolean(nullable: false),
                        DriverRealName = c.String(maxLength: 256),
                        DriverCardNo = c.String(maxLength: 256),
                        DriverHeadUrl = c.String(maxLength: 256),
                        DriverCarNo = c.String(maxLength: 256),
                        DriverCarType = c.String(maxLength: 256),
                        DriverCarLength = c.String(maxLength: 256),
                        DriverCarHeight = c.String(maxLength: 256),
                        DriverCarBrand = c.String(maxLength: 256),
                        DriverCarYear = c.String(maxLength: 256),
                        DriverLicenceUrl = c.String(maxLength: 256),
                        DriverCarVehicleUrl = c.String(maxLength: 256),
                        DriverAuthIsEnabled = c.Boolean(nullable: false),
                        DrvierLng = c.Single(nullable: false),
                        DriverLat = c.Single(nullable: false),
                        DrvierLocation = c.Geography(),
                        DrvierLocationUpdateTime = c.DateTime(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CallLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SpecwayId = c.Guid(),
                        GooderProudctId = c.Guid(),
                        SourceAccountId = c.Guid(nullable: false),
                        UserType = c.Int(nullable: false),
                        DestAccountId = c.Guid(nullable: false),
                        Message = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverWays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                        SourceCity = c.String(nullable: false, maxLength: 256),
                        DestCity = c.String(nullable: false, maxLength: 256),
                        CreateTime = c.DateTime(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        SpecwayId = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GooderProudcts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        SourceCity = c.String(nullable: false, maxLength: 256),
                        DestCityFrist = c.String(nullable: false, maxLength: 256),
                        DestCitySecond = c.String(maxLength: 256),
                        DestCityThird = c.String(maxLength: 256),
                        CarLength = c.String(nullable: false, maxLength: 256),
                        CarType = c.String(nullable: false, maxLength: 256),
                        GooderVolume = c.String(maxLength: 256),
                        GooderHeight = c.String(maxLength: 256),
                        LayStartTime = c.DateTime(nullable: false),
                        LayEndTime = c.DateTime(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Transferway = c.String(nullable: false, maxLength: 256),
                        Payway = c.String(nullable: false, maxLength: 256),
                        Remark = c.String(maxLength: 500),
                        IsRefresh = c.Boolean(nullable: false),
                        Lng = c.Single(nullable: false),
                        Lat = c.Single(nullable: false),
                        Location = c.Geography(),
                        CreateTime = c.DateTime(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        PlatForm = c.String(),
                        IP = c.String(),
                        City = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Context = c.String(),
                        MsType = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderNo = c.String(nullable: false, maxLength: 256),
                        GooderProudctId = c.Guid(nullable: false),
                        DriverDownOrderPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        GooderName = c.String(nullable: false, maxLength: 256),
                        SourceCity = c.String(nullable: false, maxLength: 256),
                        DestCityFrist = c.String(nullable: false, maxLength: 256),
                        DestCitySecond = c.String(maxLength: 256),
                        DestCityThird = c.String(maxLength: 256),
                        CarLength = c.String(nullable: false, maxLength: 256),
                        CarType = c.String(nullable: false, maxLength: 256),
                        GooderVolume = c.String(nullable: false, maxLength: 256),
                        GooderHeight = c.String(nullable: false, maxLength: 256),
                        LayStartTime = c.DateTime(nullable: false),
                        LayEndTime = c.DateTime(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Transferway = c.String(nullable: false, maxLength: 256),
                        Payway = c.String(nullable: false, maxLength: 256),
                        Remark = c.String(maxLength: 500),
                        RefundRreason = c.String(maxLength: 500),
                        IsRefund = c.Boolean(nullable: false),
                        CancelRreason = c.String(maxLength: 500),
                        OrderState = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        IsEnabled = c.Boolean(nullable: false),
                        GooderLng = c.Single(nullable: false),
                        GooderLat = c.Single(nullable: false),
                        GooderLocation_Locations = c.Geography(),
                        GooderLocation_LocationUpdateTime = c.DateTime(),
                        GooderAccountId = c.Guid(nullable: false),
                        GooderMobile = c.String(nullable: false, maxLength: 25),
                        GooderRealName = c.String(maxLength: 256),
                        GooderCardNo = c.String(maxLength: 256),
                        GooderHeadUrl = c.String(maxLength: 256),
                        GooderCardNoUrl = c.String(maxLength: 256),
                        GooderComparyName = c.String(maxLength: 256),
                        GooderComparyCity = c.String(maxLength: 256),
                        GooderComparyAddress = c.String(maxLength: 256),
                        GooderBusinesslicenseUrl = c.String(maxLength: 256),
                        GooderInfo_IsEnabled = c.Boolean(nullable: false),
                        DriverAccountId = c.Guid(nullable: false),
                        DriverMobile = c.String(nullable: false, maxLength: 25),
                        DriverRealName = c.String(maxLength: 256),
                        DriverCardNo = c.String(maxLength: 256),
                        DriverHeadUrl = c.String(maxLength: 256),
                        DriverCarNo = c.String(maxLength: 256),
                        DriverCarType = c.String(maxLength: 256),
                        DriverCarLength = c.String(maxLength: 256),
                        DriverCarHeight = c.String(maxLength: 256),
                        DriverCarBrand = c.String(maxLength: 256),
                        DriverCarYear = c.String(maxLength: 256),
                        DriverLicenceUrl = c.String(maxLength: 256),
                        DriverCarVehicleUrl = c.String(maxLength: 256),
                        DriverInfo_IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Praises",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        SpecwayId = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmsValidates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 6),
                        Mobile = c.String(),
                        Type = c.String(),
                        IP = c.String(),
                        ValidateState = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ShortName = c.String(),
                        SourcePrivince = c.String(nullable: false),
                        SourceCity = c.String(nullable: false),
                        SourceArea = c.String(),
                        SourceAddress = c.String(),
                        SourceTelehone = c.String(),
                        SourceMobile = c.String(),
                        DestCity = c.String(nullable: false),
                        DestCity1 = c.String(),
                        DestCity2 = c.String(),
                        DestCity3 = c.String(),
                        CrateOn = c.DateTime(nullable: false),
                        LateDate = c.DateTime(nullable: false),
                        HeadUrl = c.String(),
                        CardPositiveUrl = c.String(),
                        CardnegativeUrl = c.String(),
                        BusinessUrl = c.String(),
                        SceneUrl1 = c.String(),
                        SceneUrl2 = c.String(),
                        SceneUrl3 = c.String(),
                        SceneUrl4 = c.String(),
                        SceneUrl5 = c.String(),
                        SceneUrl6 = c.String(),
                        SceneUrl7 = c.String(),
                        SceneUrl8 = c.String(),
                        SceneUrl9 = c.String(),
                        SceneUrl10 = c.String(),
                        SceneUrl11 = c.String(),
                        SceneUrl12 = c.String(),
                        SceneUrl13 = c.String(),
                        SceneUrl14 = c.String(),
                        SceneUrl15 = c.String(),
                        SceneUrl16 = c.String(),
                        SceneUrl17 = c.String(),
                        SceneUrl18 = c.String(),
                        Remark = c.String(),
                        Lng = c.Single(nullable: false),
                        Lat = c.Single(nullable: false),
                        Location = c.Geography(),
                        ViewCount = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        AccountId = c.Guid(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vips");
            DropTable("dbo.Specials");
            DropTable("dbo.SmsValidates");
            DropTable("dbo.Praises");
            DropTable("dbo.Orders");
            DropTable("dbo.Messages");
            DropTable("dbo.LoginLogs");
            DropTable("dbo.GooderProudcts");
            DropTable("dbo.Favorites");
            DropTable("dbo.DriverWays");
            DropTable("dbo.CallLogs");
            DropTable("dbo.Accounts");
        }
    }
}
