using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seedwork
{
    public interface ISql
    {
        
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        
        int ExecuteCommand(string sqlCommand, params object[] parameters);


    }
}
