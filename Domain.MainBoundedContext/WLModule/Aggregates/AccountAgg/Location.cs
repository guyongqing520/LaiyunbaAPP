
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.Seedwork;
using System;
using System.Data.Entity.Spatial;


namespace Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg
{
    /// <summary>
    /// AuthInfo  information for existing Accounts
    /// For this Domain-Model, the AuthInfo is a Value-Object
    /// </summary>
    public class Location : ValueObject<Location>
    {

        /// For this Domain-Model, the AuthInfo is a Value-Object
        /// 'sets' are private as Value-Objects must be immutable, 
        /// so the only way to set properties is using the constructor 

        #region Properties


        /// <summary>
        /// Get or set good user's lng
        /// </summary>
        public float Lng { get; set; }

        /// <summary>
        /// Get or set good user's lat
        /// </summary>
        public float Lat { get; set; }


        /// <summary>
        /// Get or set drive user's loccation datetime
        /// </summary>
        public DateTime? LocationUpdateTime { get;  set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of car's location specifying its values
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="location"></param>
        /// <param name="locationUpdateTime"></param>
        public Location(float lng, float lat, DateTime? locationUpdateTime)
        {
            this.Lng = lng;
            this.Lat = lat;                     
            this.LocationUpdateTime = locationUpdateTime;
        }

        private Location() { }  //required for EF

        #endregion


    }
}
