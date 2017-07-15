using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class VipDTO
    {

        #region Properties

        public Guid Id { get; set; }

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string Remark { get; set; }
      
       
        #endregion




    }
}
