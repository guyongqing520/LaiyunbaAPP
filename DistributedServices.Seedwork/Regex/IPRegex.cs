using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{
    public class IPRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTERN = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public IPRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
