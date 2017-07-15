using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class CityDTO
    {

        #region Properties

        public int id { get; set; }
        public int cityID { get; set; }
        public string city { get; set; }
        public string father { get; set; }
       
        #endregion

    }
}
