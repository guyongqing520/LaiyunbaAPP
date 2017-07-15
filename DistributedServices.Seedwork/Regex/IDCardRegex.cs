using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{
    public class IDCardRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTERN = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;
        public IDCardRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
