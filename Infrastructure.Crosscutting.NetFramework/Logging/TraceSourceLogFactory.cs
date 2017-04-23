using Infrastructure.Crosscutting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.NetFramework.Logging
{
    public class TraceSourceLogFactory
        : ILoggerFactory
    {
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create()
        {
            return new TraceSourceLog();
        }
    }
}
