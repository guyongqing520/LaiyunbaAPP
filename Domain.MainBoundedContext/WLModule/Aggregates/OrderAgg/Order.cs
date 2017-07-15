
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.MainBoundedContext.Resources;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.OrderAgg;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.OrderAgg
{
    /// <summary>
    /// Aggregate root for Account Aggregate.
    /// </summary>
    public class Order : Entity, IValidatableObject
    {

        #region Members

        bool _IsEnabled;

        #endregion

        #region Properties

        #region order of info


        /// <summary>
        /// Get or set user mobile as username
        /// </summary>
        public string OrderNo { get; set; }


        /// <summary>
        /// Get or set user mobile as username
        /// </summary>
        public Guid GooderProudctId { get; set; }


        /// <summary>
        /// Get or set user mobile as username
        /// </summary>
        public decimal DriverDownOrderPrice { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string GooderName { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceCity { get; set; }

        /// <summary>
        /// Get or set gooder dest city one city of adress
        /// </summary>
        public string DestCityFrist { get; set; }

        /// <summary>
        /// Get or set gooder dest city Second city of adress
        /// </summary>
        public string DestCitySecond { get; set; }

        /// <summary>
        /// Get or set gooder dest city third city of adress
        /// </summary>
        public string DestCityThird { get; set; }

        /// <summary>
        /// Get Driver's car of length
        /// </summary>
        public string CarLength { get; set; }

        /// <summary>
        /// Get Driver's car of type
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// Get gooder's Volume
        /// </summary>
        public string GooderVolume { get; set; }

        /// <summary>
        /// Get gooder's height
        /// </summary>
        public string GooderHeight { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public DateTime LayStartTime { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public DateTime LayEndTime { get; set; }

        /// <summary>
        /// Get or set the unit price for this gooder
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string Transferway { get; set; }

        /// <summary>
        /// Get the gooder Payway
        /// </summary>
        public string Payway { get; set; }

        /// <summary>
        /// Get the gooder Remark
        /// </summary>
        public string Remark { get; set; }     

        /// <summary>
        /// Get the gooder RefundRreason
        /// </summary>
        public string RefundRreason { get; set; }

        /// <summary>
        /// Get the gooder RefundRreason
        /// </summary>
        public bool IsRefund { get; set; }

        /// <summary>
        /// Get the gooder Remark
        /// </summary>
        public string CancelRreason { get; set; }

        /// <summary>
        /// Get the gooder Remark
        /// </summary>
        public OrderState OrderState { get; set; }

        /// <summary>
        /// Get or set log create datetime
        /// </summary>
        public DateTime? CreateTime { get; set; }

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

        /// <summary>
        /// Get or set carlocation
        /// </summary>
        public virtual Location GooderLocation { get; set; }

        #region gooder of info

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid GooderAccountId { get; set; }

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public string GooderMobile { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public virtual GooderAuthInfo GooderInfo { get; set; }

        #endregion

        #region driver of info
        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid DriverAccountId { get; set; }


        /// <summary>
        /// Get or set user userid as AccountId 
        /// </summary>
        public string DriverMobile { get; set; }

        /// <summary>
        /// Get or set authinfo
        /// </summary>
        public virtual DriverAuthInfo DriverInfo { get; set; }

        #endregion

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


        #region IValidatableObject Members

        /// <summary>
        /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
        /// </summary>
        /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
        /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (UnitPrice < 0)
                validationResults.Add(new ValidationResult(Messages.validation_ProductDriverSoruceCity, new string[] { "UnitPrice" }));

            if (string.IsNullOrEmpty(GooderHeight) && string.IsNullOrEmpty(GooderVolume))
                validationResults.Add(new ValidationResult(Messages.validation_GooderHeightAndVolumeNotAllNull, new string[] { "GooderHeight", "GooderVolume" }));

            return validationResults;
        }

        #endregion


    }
}
