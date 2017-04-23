using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.Validator
{
    public interface IEntityValidator
    {
     
        bool IsValid<TEntity>(TEntity item)
            where TEntity : class;

        IEnumerable<String> GetInvalidMessages<TEntity>(TEntity item)
            where TEntity : class;
    }
}
