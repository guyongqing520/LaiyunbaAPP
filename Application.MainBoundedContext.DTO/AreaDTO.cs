using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class AreaDTO
    {

        #region Properties
        public int id { get; set; }
        public int areaID { get; set; }
        public string area { get; set; }
        public string father { get; set; }

        #endregion
    }
}
