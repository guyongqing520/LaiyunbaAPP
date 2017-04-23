using Infrastructure.Crosscutting.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.NetFramework.Validator
{
    public class DataAnnotationsEntityValidatorFactory
      : IEntityValidatorFactory
    {
        /// <summary>
        /// Create a entity validator
        /// </summary>
        /// <returns></returns>
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }
    }
}
