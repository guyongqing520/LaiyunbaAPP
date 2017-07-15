using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class MsgDTO
    {

        #region Properties

        public Guid Id { get; set; }

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string MsType { get; set; }


        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public DateTime CreateOn { get; set; }
      
       
        #endregion




    }
}
