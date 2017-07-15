using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{
    public class NameRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTERN = @"^[a-zA-Z\u4e00-\u9fa5]+$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public NameRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
