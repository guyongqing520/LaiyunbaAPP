
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

namespace Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg
{
    /// <summary>
    /// Aggregate root for GooderProduct Aggregate.
    /// </summary>
    public class Sms : Entity, IValidatableObject
    {

        #region Properties

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public int ValidateState { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public DateTime CreateDate { get; set; }

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

            if (string.IsNullOrEmpty(this.Code))
                validationResults.Add(new ValidationResult(Messages.validation_SmsCodeNotAllNull, new string[] { "Code" }));

            if (string.IsNullOrEmpty(this.Mobile))
                validationResults.Add(new ValidationResult(Messages.validation_SmsMobileNull, new string[] { "Mobile" }));

            return validationResults;
        }

        #endregion


    }
}
