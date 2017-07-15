using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class AccountDTO
    {
        #region Properties

        public Guid Id { get; set; }


        /// <summary>
        /// Get or set user mobile as username
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Get or set user passpword
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Get or set GooderAuthInfo_'s transaction of number
        /// </summary>
        public int TransactionNumber { get; set; }

        /// <summary>
        /// Get or set GooderAuthInfo_'s ship of number
        /// </summary>
        public int ShippedNumber { get; set; }

        /// <summary>
        /// Get or set user's type 0:good user,1:driver user
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// Get or set log create datetime
        /// </summary>
        public DateTime? CreateTime { get; set; }
       
   
        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_RealName { get; set; }


        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_CardNo { get; set; }


        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_HeadUrl { get; set; }


        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_CardNoUrl { get; set; }


        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_ComparyName { get; set; }


        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_ComparyCity { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_ComparyAddress { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string GooderAuthInfo_BusinesslicenseUrl { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public bool GooderAuthInfo_IsEnabled { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_RealName { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CardNo { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_HeadUrl { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarNo { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarType { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarLength { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarHeight { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarBrand { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarYear { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public string DriverAuthInfo_DriverLicenceUrl { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_CarVehicleUrl { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public string DriverAuthInfo_IsEnabled { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public float CarLocation_Lng { get; set; }

        /// <summary>
        /// Get or set carlocation
        /// </summary>
        public float CarLocation_Lat { get; set; }

        /// <summary>
        /// Get or set carlocation
        /// </summary>
        public double? Distance { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public DateTime? CarLocation_LocationUpdateTime { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion
    }
}
