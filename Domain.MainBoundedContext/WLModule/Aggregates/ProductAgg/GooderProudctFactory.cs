//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================
using Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class GooderProudctFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static GooderProudct CreateGooderProudct(Guid accountId, string name, string sourceCity, string destCityFrist,
            string destCitySecond,string destCityThird,string carLength,string carType,string gooderVolume,string gooderHeight,
            DateTime layStartTime,DateTime layEndTime,decimal unitPrice,string transferway,string payway,string remark,bool isRefresh,float lng,float lat
            //,DbGeography location
            )
        {
            var gooderProudct = new GooderProudct();

            gooderProudct.AccountId = accountId;
            gooderProudct.SourceCity = name;
            gooderProudct.SourceCity = sourceCity;
            gooderProudct.DestCityFrist = destCityFrist;
            gooderProudct.DestCitySecond = destCitySecond;
            gooderProudct.DestCityThird = destCityThird;
            gooderProudct.CarLength = carLength;
            gooderProudct.CarType = carType;
            gooderProudct.GooderVolume = gooderVolume;
            gooderProudct.GooderHeight = gooderHeight;
            gooderProudct.LayStartTime = layStartTime;
            gooderProudct.LayEndTime = layEndTime;
            gooderProudct.UnitPrice = unitPrice;
            gooderProudct.Transferway = transferway;
            gooderProudct.Payway = payway;
            gooderProudct.Remark = remark;
            gooderProudct.IsRefresh = isRefresh;
            gooderProudct.Lng = lng;
            gooderProudct.Lat = lat;
            //gooderProudct.Location = location;
            gooderProudct.CreateTime = DateTime.Now;
            gooderProudct.Enable();

            return gooderProudct;
        }
    }
}
