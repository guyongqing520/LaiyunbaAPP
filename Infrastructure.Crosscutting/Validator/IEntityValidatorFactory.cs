using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.Validator
{
    public interface IEntityValidatorFactory
    {
        /// <summary>
        /// Create a new IEntityValidator
        /// </summary>
        /// <returns>IEntityValidator</returns>
        IEntityValidator Create();
    }
}
