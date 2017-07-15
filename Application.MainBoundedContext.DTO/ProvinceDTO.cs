using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.DTO
{
    public class ProvinceDTO
    {

        #region Properties

        public int id { get; set; }
        public int provinceID { get; set; }
        public string province { get; set; }
       
        #endregion

    }
}
