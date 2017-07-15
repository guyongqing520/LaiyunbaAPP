using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedServices.Seedwork.Sms
{
    public class CodeSms : SmsBase
    {
        public CodeSms(string mobile, int tpl_id,string tpl_value)
            : base(mobile, Setting.SmsUrl, Setting.UserKey, tpl_id, tpl_value, Setting.Dtype)
        {

        }
    }
}
