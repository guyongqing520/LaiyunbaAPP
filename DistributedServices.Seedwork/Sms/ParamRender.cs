using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedServices.Seedwork.Sms
{
    public class ParamRender
    {
        private Dictionary<string, string> replaceVariables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);


        public void RegisterVariable(string varName, string value)
        {
            if (!string.IsNullOrEmpty(varName))
            {
                if (replaceVariables.ContainsKey(varName))
                    replaceVariables[varName] = value;
                else
                    replaceVariables.Add(varName, value);
            }
        }
        public string this[string key]
        {
            get
            {
                return replaceVariables[key];
            }
            set
            {
                RegisterVariable(key, value);
            }
        }
        public Dictionary<string, string> ReplaceVariables
        {
            get { return replaceVariables; }
            set { replaceVariables = value; }
        }

    }
}
