//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg
{
    /// <summary>
    /// This is the factory for DriverWay creation, which means that the main purpose
    /// is to encapsulate the creation knowledge.
    /// What is created is a transient entity instance, with nothing being said about persistence as yet
    /// </summary>
    public static class SpecwayFactory
    {
        /// <summary>
        /// Create a new DriverWay
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="sourceCity"></param>
        /// <param name="destCity"></param>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public static Specway CreateSpecway(Guid accountId, string name, string sourcePrivince, string sourceCity,
            string sourceArea, string sourceAddress, string sourceTelehone, string sourceMobile, string destCity, string destCity1,
            string destCity2, string destCity3, string headUrl, string cardPositiveUrl, string cardnegativeUrl, string businessUrl,
            string remark, int viewCount, string sceneUrl1, string sceneUrl2, string sceneUrl3, string sceneUrl4, string sceneUrl5, string sceneUrl6, string sceneUrl7, string sceneUrl8, string sceneUrl9, string sceneUrl10, string sceneUrl11, string sceneUrl12, string sceneUrl13, string sceneUrl14, string sceneUrl15, string sceneUrl16, string sceneUrl17, string sceneUrl18,float lng, float lat
            )
        {
            var specway = new Specway();

            specway.AccountId = accountId;
            specway.Name = name;

            specway.SourcePrivince = sourcePrivince;
            specway.SourceCity = sourceCity;

            specway.SourceCity = sourceCity;
            specway.SourceArea = sourceArea;

            specway.SourceAddress = sourceAddress;
            specway.SourceTelehone = sourceTelehone;
            specway.SourceMobile = sourceMobile;

            specway.DestCity = destCity;
            specway.DestCity1 = destCity1;
            specway.DestCity2 = destCity2;
            specway.DestCity3 = destCity3;

            specway.HeadUrl = headUrl;
            specway.CardPositiveUrl = cardPositiveUrl;
            specway.CardnegativeUrl = cardnegativeUrl;
            specway.BusinessUrl = businessUrl;

            specway.Remark = remark;
            specway.ViewCount = viewCount;

            specway.SceneUrl1 = sceneUrl1;
            specway.SceneUrl2 = sceneUrl2;
            specway.SceneUrl3 = sceneUrl3;
            specway.SceneUrl4 = sceneUrl4;
            specway.SceneUrl5 = sceneUrl5;
            specway.SceneUrl6 = sceneUrl6;
            specway.SceneUrl7 = sceneUrl7;
            specway.SceneUrl8 = sceneUrl8;
            specway.SceneUrl8 = sceneUrl9;
            specway.SceneUrl8 = sceneUrl10;
            specway.SceneUrl8 = sceneUrl11;
            specway.SceneUrl8 = sceneUrl12;
            specway.SceneUrl8 = sceneUrl13;
            specway.SceneUrl8 = sceneUrl14;
            specway.SceneUrl8 = sceneUrl15;
            specway.SceneUrl8 = sceneUrl16;
            specway.SceneUrl8 = sceneUrl17;
            specway.SceneUrl8 = sceneUrl18;

            specway.Lng = lng;
            specway.Lat = lat;
            specway.Location = DbGeography.FromText(string.Format("POINT({0} {1})", lng, lat));

            specway.CrateOn = DateTime.Now;
            specway.LateDate = DateTime.Now;
            specway.GenerateNewIdentity();

            return specway;
        }
    }
}
