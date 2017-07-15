//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class SmsFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static Sms CreateSms(string code, string mobile, string type, string ip, int validateState)
        {
            var sms = new Sms();

            sms.Code = code;
            sms.Mobile = mobile;

            sms.Type = type;
            sms.IP = ip;

            sms.ValidateState = validateState;
            sms.CreateDate = DateTime.Now;
            sms.GenerateNewIdentity();

            return sms;
        }
    }
}
