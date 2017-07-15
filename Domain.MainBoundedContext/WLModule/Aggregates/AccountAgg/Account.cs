
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.MainBoundedContext.Resources;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg
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
        /// Get or set gooder's transaction of number
        /// </summary>
        public int TransactionNumber { get; set; }

        /// <summary>
        /// Get or set gooder's ship of number
        /// </summary>
        public int ShippedNumber { get; set; }

        /// <summary>
        /// Get or set user's type 0:good user,1:driver user
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Get or set log create datetime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public virtual GooderAuthInfo GooderAuthInfo { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public virtual DriverAuthInfo DriverAuthInfo { get; set; }

        /// <summary>
        /// Get or set carlocation
        /// </summary>
        public virtual Location CarLocation { get; set; }


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
        /// change the authinfo for this account
        /// </summary>
        /// <param name="authinfo">the new authinfo for this account</param>
        public void ChangeShippedNumber(int shippedNumber)
        {
            if (shippedNumber != 0)
            {
                this.ShippedNumber = shippedNumber;
            }
        }

        /// <summary>
        /// change the authinfo for this account
        /// </summary>
        /// <param name="authinfo">the new authinfo for this account</param>
        public void ChangeTransactionNumber(int transactionNumber)
        {
            if (transactionNumber != 0)
            {
                this.TransactionNumber = TransactionNumber;
            }
        }

        /// <summary>
        /// change the authinfo for this account
        /// </summary>
        /// <param name="authinfo">the new authinfo for this account</param>
        public void ChangeDriverAuthInfo(DriverAuthInfo authinfo)
        {
            if (authinfo != null)
            {
                this.DriverAuthInfo = authinfo;
            }
        }

        /// <summary>
        /// change the carlocation for this account
        /// </summary>
        /// <param name="carlocation">the new carlocation for this account</param>
        public void ChangeCarLocation(Location carlocation)
        {
            if (carlocation != null)
            {
                this.CarLocation = carlocation;
            }
        }

        /// <summary>
        /// change the authinfo for this account
        /// </summary>
        /// <param name="authinfo">the new authinfo for this account</param>
        public void ChangeGooderAuthInfo(GooderAuthInfo authinfo)
        {
            if (authinfo != null)
            {
                this.GooderAuthInfo = authinfo;
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

        #region IValidatableObject Members

        /// <summary>
        /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
        /// </summary>
        /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
        /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            //-->Check mobile property
            if (String.IsNullOrWhiteSpace(this.Mobile))
            {
                validationResults.Add(new ValidationResult(Messages.validation_MobileCannotBeNull,
                                                           new string[] { "Mobile" }));
            }

            //-->Check password propertys
            if (String.IsNullOrWhiteSpace(this.PassWord))
            {
                validationResults.Add(new ValidationResult(Messages.validation_PassWordCannotBeBull,
                                                           new string[] { "PassWord" }));
            }

            return validationResults;
        }

        #endregion

    }
}
