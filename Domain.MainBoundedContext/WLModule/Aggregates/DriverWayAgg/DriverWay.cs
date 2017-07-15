
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

namespace Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg
{
    /// <summary>
    /// Aggregate root for Account Aggregate.
    /// </summary>
    public class DriverWay : Entity, IValidatableObject
    {

        #region Members

        bool _IsEnabled;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set driver user's userid as AccountId
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set driver user source of city
        /// </summary>
        public string SourceCity { get; set; }

        /// <summary>
        /// Get or set driver user dest of city
        /// </summary>
        public string DestCity { get; set; }

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


        /// <summary>
        /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
        /// </summary>
        /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
        /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrEmpty(SourceCity))
                validationResults.Add(new ValidationResult(Messages.validation_ProductDriverSoruceCity, new string[] { "SoruceCity" }));

            if (string.IsNullOrEmpty(DestCity))
                validationResults.Add(new ValidationResult(Messages.validation_ProductDriverDestCity, new string[] { "DestCity" }));

            return validationResults;
        }
    }
}
