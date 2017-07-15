using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace DistributedServices.Seedwork.Regex
{
    public class TelePhoneRegex : System.Text.RegularExpressions.Regex
    {
        private const string PATTETN = @"^(\d{3,4}-)?\d{7,8}$";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;
        public TelePhoneRegex()
            : base(PATTETN, OPTIONS)
        { }
    }
}
