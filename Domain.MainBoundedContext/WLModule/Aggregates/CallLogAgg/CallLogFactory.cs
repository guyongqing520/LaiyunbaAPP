//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.CallLogAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class CallLogFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static CallLog CreateCallLog(Guid? specwayId, Guid? gooderProudctId, Guid sourceAccountId, UserType userType, Guid destAccountId, string message)
        {
            var callLog = new CallLog();

            callLog.SpecwayId = specwayId;
            callLog.GooderProudctId = gooderProudctId;

            callLog.SourceAccountId = sourceAccountId;
            callLog.UserType = userType;

            callLog.DestAccountId = destAccountId;
            callLog.Message = message;

            callLog.CreateOn = DateTime.Now;

            callLog.GenerateNewIdentity();


            return callLog;
        }

        

    }
}
