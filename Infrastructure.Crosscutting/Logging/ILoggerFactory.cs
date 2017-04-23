﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.Logging
{
    public interface ILoggerFactory
    {
        /// <summary>
        /// Create a new ILog
        /// </summary>
        /// <returns>The ILog created</returns>
        ILogger Create();
    }
}
