using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DistributedServices.Seedwork.Regex
{
    public class NickNameRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTERN = @"^[a-zA-Z0-9_\u4e00-\u9fa5]+$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public NickNameRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
