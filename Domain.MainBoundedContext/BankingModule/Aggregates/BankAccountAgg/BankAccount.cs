
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.MainBoundedContext.Resources;
using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg
{
    /// <summary>
    /// Aggregate root for Account Aggregate.
    /// </summary>
    public class BankAccount : Entity, IValidatableObject
    {

        #region Properties

        /// <summary>
        /// Get or set driver user's userid as AccountId
        /// </summary>
        public Guid AccountId { get; private set; }


        /// <summary>
        /// Get the current balance of this account
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// get user bank'account for item
        /// </summary>
        HashSet<BankAccountActivity> _bankAccountActivity;

        /// <summary>
        /// Get the bank account activity into this account
        /// </summary>
        public virtual ICollection<BankAccountActivity> BankAccountActivity
        {
            get
            {
                if (_bankAccountActivity == null)
                    _bankAccountActivity = new HashSet<BankAccountActivity>();

                return _bankAccountActivity;
            }
            set
            {
                _bankAccountActivity = new HashSet<BankAccountActivity>(value);
            }
        }


        /// <summary>
        /// Get the state of this account
        /// </summary>
        public bool Locked { get; private set; }


        /// <summary>
        /// Lock current bank account
        /// </summary>
        public void Lock()
        {
            if (!Locked)
                Locked = true;
        }

        /// <summary>
        /// Un lock current bank account
        /// </summary>
        public void UnLock()
        {
            if (Locked)
                Locked = false;
        }

        #endregion


        #region Members

        /// <summary>
        /// Deposit momey into this bank account
        /// </summary>
        /// <param name="amount">the amount of money to deposit </param>
        public void DepositMoney(decimal amount,string reason)
        {
            //if (amount < 0) throw new ArgumentException(Messages.exception_BankAccountInvalidWithdrawAmount);

            //DepositMoney is a term of our Ubiquitous Language. Means adding money to this account
            if (!this.Locked)
            {
                //set balance
                checked
                {
                    Balance += amount;

                    //anotate activity
                    var activity = new BankAccountActivity()
                    {
                        Date = DateTime.UtcNow,
                        Amount = amount,
                        ActivityDescription = reason,
                        BankAccountId = Id
                    };
                    activity.GenerateNewIdentity();

                    this.BankAccountActivity.Add(activity);
                }
            }
            //else
            //    throw new InvalidOperationException(Messages.exception_BankAccountCannotDeposit);
        }

        /// <summary>
        /// WithdrawMoney operation over this bankaccount
        /// </summary>
        /// <param name="amount">The amount of money for this withdraw operation</param>
        public void WithdrawMoney(decimal amount,string reason)
        {
            //if ( amount <= 0 )  throw new ArgumentException(Messages.exception_BankAccountInvalidWithdrawAmount);

            //WithdrawMoney is a term of our Ubiquitous Language. Means deducting money to this account
            if (CanBeWithdrawed(amount))
            {
                checked
                {
                    this.Balance -= amount;

                    //anotate activity
                    var activity = new BankAccountActivity()
                    {
                        Date = DateTime.Now,
                        Amount = -amount,
                        ActivityDescription = reason,
                        BankAccountId = Id
                    };
                    activity.GenerateNewIdentity();

                    this.BankAccountActivity.Add(activity);
                }
            }
            //else
            //    throw new InvalidOperationException(Messages.exception_BankAccountCannotWithdraw);
        }

        /// <summary>
        /// Check if in this bankaccount is posible withdraw <paramref name="amount"/>
        /// </summary>
        /// <param name="amount">The amount of money </param>
        /// <returns>True if is posible perform the operation, else false</returns>
        public bool CanBeWithdrawed(decimal amount)
        {
            return !Locked && (this.Balance >= amount);
        }

        /// <summary>
        /// Set customer for this bank account
        /// </summary>
        /// <param name="customer">The customer owner of this bank account</param>
        public void SetCustomerOwnerOfThisBankAccount(Guid customerId)
        {
            if (customerId != Guid.Empty)
            {
                //throw new ArgumentException(Messages.exception_CannotAssociateTransientOrNullCustomer);
            }

            //fix id and set reference
            this.AccountId = customerId;
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

            //if(this.AccountId == Guid.Empty)
            //    validationResults.Add(new ValidationResult(Messages.validation_BankAccountCustomerIdIsEmpty, new string[] { "AccountId" }));

            return validationResults;
        }

        #endregion
    }
}
