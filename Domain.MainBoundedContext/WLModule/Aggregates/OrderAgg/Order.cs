
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg
{
    /// <summary>
    /// Aggregate root for Account Aggregate.
    /// </summary>
    public class Account : Entity, IValidatableObject
    {

        #region Members

        bool _IsEnabled;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set user mobile as username
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Get or set user passpword
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Get or set user's type 0:good user,1:driver user
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Get or set log create datetime
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public virtual AuthInfo AuthInfo { get; set; }

        /// <summary>
        /// Get or set carlocation
        /// </summary>
        public virtual CarLocation CarLocation { get; set; }

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

        #endregion

        #region Public Methods

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

    }
}
