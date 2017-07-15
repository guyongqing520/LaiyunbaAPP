
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.Seedwork;

namespace Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg
{
    /// <summary>
    /// AuthInfo  information for existing Accounts
    /// For this Domain-Model, the AuthInfo is a Value-Object
    /// </summary>
    public class DriverAuthInfo : ValueObject<DriverAuthInfo>
    {

        #region Members

        bool _IsEnabled;

        #endregion

        /// For this Domain-Model, the AuthInfo is a Value-Object
        /// 'sets' are private as Value-Objects must be immutable, 
        /// so the only way to set properties is using the constructor 

        #region Properties

        /// <summary>
        /// Get or set user's real name
        /// </summary>
        public string RealName { get;  set; }

        /// <summary>
        /// Get or set user cardno info
        /// </summary>
        public string CardNo { get;  set; }

        /// <summary>
        /// Get user head image icon
        /// </summary>
        public string HeadUrl { get;  set; }

        /// <summary>
        /// Get Driver's car of brand
        /// </summary>
        public string CarNo { get;  set; }

        /// <summary>
        /// Get Driver car's type info
        /// </summary>
        public string CarType { get;  set; }

        /// <summary>
        /// Get Driver's car of length
        /// </summary>
        public string CarLength { get;  set; }

        /// <summary>
        /// Get Driver's car of height
        /// </summary>
        public string CarHeight { get;  set; }
        
        /// <summary>
        /// Get Driver's car of brand
        /// </summary>
        public string CarBrand { get;  set; }

        /// <summary>
        /// Get Driver's car of create date of year
        /// </summary>
        public string CarYear { get;  set; }

        /// <summary>
        /// Get Driver's car of licence image url 
        /// </summary>
        public string DriverLicenceUrl { get;  set; }

        /// <summary>
        /// Get Driver's car of vehicle image url 
        /// </summary>
        public string CarVehicleUrl { get;  set; }



        /// <summary>
        /// Get log current state
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            private set
            {
                _IsEnabled = value;
            }
        }

        /// <summary>
        /// Set log info of state is false for disable
        /// </summary>
        public void Disable()
        {
            if (IsEnabled)
                this._IsEnabled = false;
        }

        /// <summary>
        /// Set log info of state is true for enable
        /// </summary>
        public void Enable()
        {
            if (!IsEnabled)
                this._IsEnabled = true;
        }

        #endregion

        #region Constructor



        /// <summary>
        /// Create a new instance of authinfo for driver'user location specifying its values
        /// </summary>
        /// <param name="realname"></param>
        /// <param name="cardno"></param>
        /// <param name="cardnourl"></param>
        /// <param name="headurl"></param>
        /// <param name="comparyname"></param>
        /// <param name="comparyprivince"></param>
        /// <param name="comparyaddress"></param>
        /// <param name="businesslicenseurl"></param>
        public DriverAuthInfo(string realName, string cardNo, string headUrl, string carType, string carLength,string carNo, string carHeight, string carBrand, string carYear, string drivelLicenceUrl, string carvehicleUrl)
        {
            this.RealName = realName;
            this.CardNo = cardNo;
            this.HeadUrl = headUrl;
            this.CarNo = cardNo;
            this.CarType = carType;
            this.CarLength = carLength;
            this.CarHeight = carHeight;
            this.CarBrand = carBrand;
            this.CarYear = carYear;
            this.DriverLicenceUrl = drivelLicenceUrl;
            this.CarVehicleUrl = carvehicleUrl;
        }


        private DriverAuthInfo() { }  //required for EF

        #endregion
    }
}
