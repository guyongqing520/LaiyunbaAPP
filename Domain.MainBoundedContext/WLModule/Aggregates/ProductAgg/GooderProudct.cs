
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.MainBoundedContext.Resources;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg
{
    /// <summary>
    /// Aggregate root for GooderProduct Aggregate.
    /// </summary>
    public class GooderProudct : Entity, IValidatableObject
    {

        #region Members

        bool _IsEnabled;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Mobile { get; set; }

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
        public decimal UnitPrice { get; set; }

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
        /// Get the gooder Remark
        /// </summary>
        public bool IsRefresh { get; set; }

        /// <summary>
        /// Get or set good user's lng
        /// </summary>
        public float Lng { get; set; }

        /// <summary>
        /// Get or set good user's lat
        /// </summary>
        public float Lat { get; set; }

         //<summary>
         //Get or set good user's location info
         //</summary>
        public DbGeography Location { get; set; }

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

            if (string.IsNullOrEmpty(this.Name))
                validationResults.Add(new ValidationResult(Messages.validation_GooderNameNotAllNull, new string[] { "Name" }));

            if (UnitPrice < 0)
                validationResults.Add(new ValidationResult(Messages.validation_GooderUnitPriceLetZero, new string[] { "UnitPrice" }));

            if (string.IsNullOrEmpty(this.SourceCity))
                validationResults.Add(new ValidationResult(Messages.validation_GooderSourceCityNull, new string[] { "SourceCity" }));

            if (string.IsNullOrEmpty(this.DestCityFrist))
                validationResults.Add(new ValidationResult(Messages.validation_GooderDestCityFristNull, new string[] { "DestCityFrist" }));

            if (string.IsNullOrEmpty(this.GooderHeight) && string.IsNullOrEmpty(this.GooderVolume))
                validationResults.Add(new ValidationResult(Messages.validation_GooderHeightAndVolumeNotAllNull, new string[] { "GooderHeight", "GooderVolume" }));

            if (string.IsNullOrEmpty(this.CarLength))
                validationResults.Add(new ValidationResult(Messages.validation_GooderCarLengthNull, new string[] { "CarLength" }));

            if (string.IsNullOrEmpty(this.CarType))
                validationResults.Add(new ValidationResult(Messages.validation_GooderCarTypeNull, new string[] { "CarType" }));

            if (string.IsNullOrEmpty(this.Payway))
                validationResults.Add(new ValidationResult(Messages.validation_GooderPaywayNull, new string[] { "Payway" }));

            if (string.IsNullOrEmpty(this.Transferway))
                validationResults.Add(new ValidationResult(Messages.validation_GooderTransferwayNull, new string[] { "Transferway" }));


            return validationResults;
        }

        #endregion


    }
}
