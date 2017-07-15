using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace DistributedServices.Seedwork.Regex
{

    public class TitleRegex : System.Text.RegularExpressions.Regex
    {

        private const string PATTERN = @"(?<=<title>)[\s\S]*?(?=</title>)";
        private const RegexOptions OPTIONS = RegexOptions.IgnoreCase;

        public TitleRegex()
            : base(PATTERN, OPTIONS)
        { }
    }
}
