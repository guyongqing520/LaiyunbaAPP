using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{


    public class MobileRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTETN = @"^1[3456789][0-9]{9}$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;
        public MobileRegex()
            : base(PATTETN, OPTIONS)
        { }
    }
}
