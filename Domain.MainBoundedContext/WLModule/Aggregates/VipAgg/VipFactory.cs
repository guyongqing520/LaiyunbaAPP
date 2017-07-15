//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.VipAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class VipFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static Vip CreateVip(DateTime createOn, DateTime endDateTime, Guid accountId, string remark)
        {
            var vip = new Vip();

            vip.CreateOn = createOn;
            vip.EndDateTime = endDateTime;

            vip.AccountId = accountId;
            vip.Remark = remark;

            vip.GenerateNewIdentity();

            return vip;
        }
    }
}
