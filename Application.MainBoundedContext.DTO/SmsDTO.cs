using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class SmsDTO
    {

        #region Properties

        public Guid Id { get; set; }

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public int ValidateState { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public DateTime CreateDate { get; set; }
      
       
        #endregion




    }
}
