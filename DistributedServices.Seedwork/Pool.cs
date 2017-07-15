using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedServices.Seedwork
{
    public class Pool<T>
      where T : new()
    {
        public readonly static T Instance = new T();
    }
}
