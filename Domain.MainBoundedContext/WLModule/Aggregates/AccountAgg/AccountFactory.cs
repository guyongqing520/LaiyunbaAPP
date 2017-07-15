//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg
{
    /// <summary>
    /// This is the factory for Account creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class AccountFactory
    {
        /// <summary>
        /// Create a new Account
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public static Account CreateAccount(string mobile, string password, UserType usertype, DriverAuthInfo driverAuthInfo, GooderAuthInfo gooderAuthInfo, Location carLocation)
        {
            var account = new Account();

            account.GenerateNewIdentity();

            account.Mobile = mobile;
            account.PassWord = password;

            account.UserType = usertype;
            account.CreateTime = DateTime.Now;

            account.ChangeDriverAuthInfo(driverAuthInfo);
            account.ChangeGooderAuthInfo(gooderAuthInfo);
            account.ChangeCarLocation(carLocation) ;

            account.Enable();
            

            return account;
        }
    }
}
