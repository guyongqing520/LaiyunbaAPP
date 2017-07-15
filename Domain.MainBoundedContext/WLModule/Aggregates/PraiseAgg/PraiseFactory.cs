//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.PraiseAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class PraiseFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static Praise CreatePraise(Guid accountId, Guid specwayId)
        {
            var praise = new Praise();

            praise.AccountId = accountId;
            praise.SpecwayId = specwayId;

            praise.CreateOn = DateTime.Now;
            praise.GenerateNewIdentity();

            return praise;
        }
    }
}
