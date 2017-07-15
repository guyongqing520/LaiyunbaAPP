using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{
    public class QQRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTERN = @"^\d+$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public QQRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
