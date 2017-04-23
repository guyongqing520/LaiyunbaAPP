
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.UserInfoAgg
{
    /// <summary>
    /// AuthInfo  information for existing Accounts
    /// For this Domain-Model, the AuthInfo is a Value-Object
    /// </summary>
    public class CarLocation : ValueObject<CarLocation>
    {

        /// For this Domain-Model, the AuthInfo is a Value-Object
        /// 'sets' are private as Value-Objects must be immutable, 
        /// so the only way to set properties is using the constructor 

        #region Properties


        /// <summary>
        /// Get or set good user's lng
        /// </summary>
        public float Lng { get; private set; }

        /// <summary>
        /// Get or set good user's lat
        /// </summary>
        public float Lat { get; private set; }

        /// <summary>
        /// Get or set good user's location info
        /// </summary>
        public DbGeography Location { get; set; }

        /// <summary>
        /// Get or set drive user's loccation datetime
        /// </summary>
        public DateTime LocationUpdateTime { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of car's location specifying its values
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="location"></param>
        /// <param name="locationUpdateTime"></param>
        public CarLocation(float lng, float lat, DbGeography location, DateTime locationUpdateTime)
        {
            this.Lng = lng;
            this.Lat = lat;
            this.Location = location;
            this.LocationUpdateTime = locationUpdateTime;
        }

        private CarLocation() { }  //required for EF

        #endregion


    }
}
