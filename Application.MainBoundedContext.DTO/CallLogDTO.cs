using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class CallLogDTO
    {

        #region Properties

        public Guid Id { get; set; }

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid? SpecwayId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public Guid? GooderProudctId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public Guid SourceAccountId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public Guid DestAccountId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public DateTime CreateOn { get; set; }
       
        #endregion




    }
}
