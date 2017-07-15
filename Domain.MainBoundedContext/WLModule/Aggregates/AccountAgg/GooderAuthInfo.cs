
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
    public class GooderAuthInfo : ValueObject<GooderAuthInfo>
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
        public string RealName { get; set; }

        /// <summary>
        /// Get or set user cardno info
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// Get user head image icon
        /// </summary>
        public string HeadUrl { get; set; }

        /// <summary>
        /// Get or set user cardno info
        /// </summary>
        public string CardNoUrl { get; set; }

        /// <summary>
        /// Get good's compary of name
        /// </summary>
        public string ComparyName { get; set; }

        /// <summary>
        /// Get good's compary of city
        /// </summary>
        public string ComparyCity { get; set; }

        /// <summary>
        /// Get good's compary of address
        /// </summary>
        public string ComparyAddress { get; set; }

        /// <summary>
        /// Get good's compary of business or license's images of url
        /// </summary>
        public string BusinesslicenseUrl { get;  set; }


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
        public GooderAuthInfo(string realName, string cardNo, string cardnoUrl, string headUrl, string comparyName, string comparyCity, string comparyAddress, string businesslicenseUrl)
        {
            this.RealName = realName;
            this.CardNo = cardNo;
            this.CardNoUrl = cardnoUrl;
            this.HeadUrl = headUrl;
            this.ComparyName = comparyName;
            this.ComparyCity = comparyCity;
            this.ComparyAddress = comparyAddress;
            this.BusinesslicenseUrl = businesslicenseUrl;
            
        }

        private GooderAuthInfo() { }  //required for EF

        #endregion
    }
}
