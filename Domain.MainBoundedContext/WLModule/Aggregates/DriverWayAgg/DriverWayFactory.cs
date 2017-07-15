//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class DriverWayFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static DriverWay CreateDriverWay(Guid accountId,string sourceCity,string destCity,string createTime)
        {
            var driverway = new DriverWay();

            driverway.AccountId = accountId;
            driverway.SourceCity = sourceCity;
            driverway.DestCity = destCity;
            driverway.CreateTime = DateTime.Now;
            driverway.Enable();
            return driverway;
        }
    }
}
