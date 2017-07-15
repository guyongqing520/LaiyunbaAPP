//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class LoginLogFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static LoginLog CreateLoginLog(Guid accountId, DateTime loginDate, string platForm, string ip, string city)
        {
            var loginLog = new LoginLog();

            loginLog.AccountId = accountId;
            loginLog.LoginDate = loginDate;

            loginLog.PlatForm = platForm;
            loginLog.IP = ip;

            loginLog.City = city;
            loginLog.CreateDate = DateTime.Now;

            return loginLog;
        }
    }
}
