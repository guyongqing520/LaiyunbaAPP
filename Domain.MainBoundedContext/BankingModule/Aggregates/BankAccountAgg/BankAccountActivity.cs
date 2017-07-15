
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

namespace Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg
{
     /// <summary>
    /// The bank transferLog representation
    /// </summary>
    public class BankAccountActivity
        :Entity
    {
        #region Properties

        /// <summary>
        /// Get or set the bank account identifier
        /// </summary>
        public Guid BankAccountId { get; set; }

        /// <summary>
        /// The bank transferLog amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Get or set driver user's userid as AccountId
        /// </summary>
        public Guid FromAccountId { get; private set; }

        /// <summary>
        /// Get or set driver user's userid as AccountId
        /// </summary>
        public Guid ToAccountId { get; private set; } 

        /// <summary>
        /// Get or set the activity description
        /// </summary>
        public string ActivityDescription { get; set; }

        /// <summary>
        /// The bank transferLog date
        /// </summary>
        public DateTime? Date { get; set; }

        #endregion
    }
}
