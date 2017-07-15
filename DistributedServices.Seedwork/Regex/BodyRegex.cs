using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{
    public class BodyRegex : System.Text.RegularExpressions.Regex
    {

        private const string PATTERN = @"(?<=<body.*>)[\s\S]*?(?=</body>)";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public BodyRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
