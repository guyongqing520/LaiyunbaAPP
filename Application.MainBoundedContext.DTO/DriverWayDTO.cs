using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class DriverWayDTO
    {

        #region Properties

        public Guid Id { get; set; }

        /// <summary>
        /// Get or set driver user's userid as AccountId
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set driver user source of city
        /// </summary>
        public string SourceCity { get; set; }

        /// <summary>
        /// Get or set driver user dest of city
        /// </summary>
        public string DestCity { get; set; }

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
