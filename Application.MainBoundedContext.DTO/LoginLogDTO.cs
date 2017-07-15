using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class LoginLogDTO
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
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string PlatForm { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public DateTime CreateDate { get; set; }
      
       
        #endregion




    }
}
