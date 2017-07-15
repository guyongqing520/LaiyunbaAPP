using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class GooderProudctDTO
    {

        #region Properties

        public Guid Id { get; set; }


        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceCity { get; set; }

        /// <summary>
        /// Get or set gooder dest city one city of adress
        /// </summary>
        public string DestCityFrist { get; set; }

        /// <summary>
        /// Get or set gooder dest city Second city of adress
        /// </summary>
        public string DestCitySecond { get; set; }

        /// <summary>
        /// Get or set gooder dest city third city of adress
        /// </summary>
        public string DestCityThird { get; set; }

        /// <summary>
        /// Get Driver's car of length
        /// </summary>
        public string CarLength { get; set; }

        /// <summary>
        /// Get Driver's car of type
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// Get gooder's Volume
        /// </summary>
        public string GooderVolume { get; set; }

        /// <summary>
        /// Get gooder's height
        /// </summary>
        public string GooderHeight { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public DateTime LayStartTime { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public DateTime LayEndTime { get; set; }

        /// <summary>
        /// Get or set the unit price for this gooder
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string Transferway { get; set; }

        /// <summary>
        /// Get the gooder Payway
        /// </summary>
        public string Payway { get; set; }

        /// <summary>
        /// Get the gooder Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Get the gooder Remark
        /// </summary>
        public bool IsRefresh { get; set; }

        /// <summary>
        /// Get or set good user's lng
        /// </summary>
        public float Lng { get; set; }

        /// <summary>
        /// Get or set good user's lat
        /// </summary>
        public float Lat { get; set; }

        /// <summary>
        /// Get or set good user's location info
        /// </summary>
        //public DbGeography Location { get; set; }

        /// <summary>
        /// Get or set log create datetime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

    }
}
