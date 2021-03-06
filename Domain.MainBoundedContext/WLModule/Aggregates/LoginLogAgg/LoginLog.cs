﻿
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

namespace Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg
{
    /// <summary>
    /// Aggregate root for GooderProduct Aggregate.
    /// </summary>
    public class LoginLog : Entity, IValidatableObject
    {

        #region Properties

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string PlatForm { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string City { get; set; }

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
            return validationResults;
        }

        #endregion


    }
}
