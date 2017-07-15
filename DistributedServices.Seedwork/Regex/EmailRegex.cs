using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace DistributedServices.Seedwork.Regex
{
    public class EmailRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTERN = @"^[a-z0-9A-Z]+[\w\-\.]*@[a-z0-9\-]+(?>\.\w+){1,4}$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public EmailRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
