
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg
{
    /// <summary>
    /// AuthInfo  information for existing Accounts
    /// For this Domain-Model, the AuthInfo is a Value-Object
    /// </summary>
    public class AuthInfo : ValueObject<AuthInfo>
    {

        /// For this Domain-Model, the AuthInfo is a Value-Object
        /// 'sets' are private as Value-Objects must be immutable, 
        /// so the only way to set properties is using the constructor 

        #region Properties

        /// <summary>
        /// Get or set user's real name
        /// </summary>
        public string RealName { get; private set; }

        /// <summary>
        /// Get or set user cardno info
        /// </summary>
        public string CardNo { get; private set; }

        /// <summary>
        /// Get or set user cardno info
        /// </summary>
        public string CardNoUrl { get; private set; }

        /// <summary>
        /// Get user head image icon
        /// </summary>
        public string HeadUrl { get; private set; }

        /// <summary>
        /// Get user car's no 
        /// </summary>
        public string CarNo { get; private set; }

        /// <summary>
        /// Get Driver car's type info
        /// </summary>
        public string CarType { get; private set; }

        /// <summary>
        /// Get Driver's car of length
        /// </summary>
        public int CarLength { get; private set; }

        /// <summary>
        /// Get Driver's car of height
        /// </summary>
        public int CarHeight { get; private set; }

        /// <summary>
        /// Get Driver's car of brand
        /// </summary>
        public string CarBrand { get; private set; }

        /// <summary>
        /// Get Driver's car of create date of year
        /// </summary>
        public string CarYear { get; private set; }

        /// <summary>
        /// Get Driver's car of licence image url 
        /// </summary>
        public string DriverLicenceUrl { get; private set; }

        /// <summary>
        /// Get Driver's car of vehicle image url 
        /// </summary>
        public string CarVehicleUrl { get; private set; }

        /// <summary>
        /// Get good's compary of name
        /// </summary>
        public string ComparyName { get; private set; }

        /// <summary>
        /// Get good's compary of privince
        /// </summary>
        public string ComparyPrivince { get; private set; }

        /// <summary>
        /// Get good's compary of city
        /// </summary>
        public string ComparyCity { get; private set; }

        /// <summary>
        /// Get good's compary of address
        /// </summary>
        public string ComparyAddress { get; private set; }

        /// <summary>
        /// Get good's compary of business or license's images of url
        /// </summary>
        public string BusinesslicenseUrl { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of authinfo for goods'user location specifying its values
        /// </summary>
        /// <param name="realname"></param>
        /// <param name="cardno"></param>
        /// <param name="cardnourl"></param>
        /// <param name="headurl"></param>
        /// <param name="comparyname"></param>
        /// <param name="comparyprivince"></param>
        /// <param name="comparyaddress"></param>
        /// <param name="businesslicenseurl"></param>
        public AuthInfo(string realName, string cardNo, string cardnoUrl, string headUrl, string comparyName, string comparyPrivince, string comparyAddress, string businesslicenseUrl)
        {
            this.RealName = realName;
            this.CardNo = cardNo;
            this.CardNoUrl = cardnoUrl;
            this.HeadUrl = headUrl;
            this.ComparyName = comparyName;
            this.ComparyPrivince = comparyPrivince;
            this.ComparyAddress = comparyAddress;
            this.BusinesslicenseUrl = businesslicenseUrl;
        }

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
        public AuthInfo(string realName, string cardNo, string headUrl, string carNo, string carType, int carLength, int carHeight, string carBrand, string carYear, string drivelLicenceUrl, string carvehicleUrl)
        {
            this.RealName = realName;
            this.CardNo = cardNo;
            this.CardNoUrl = headUrl;
            this.HeadUrl = carNo;
            this.CarType = carType;
            this.CarLength = carLength;
            this.CarHeight = carHeight;
            this.CarBrand = carBrand;
            this.BusinesslicenseUrl = carYear;
            this.DriverLicenceUrl = drivelLicenceUrl;
            this.CarVehicleUrl = carvehicleUrl;
        }


        private AuthInfo() { }  //required for EF

        #endregion
    }
}
