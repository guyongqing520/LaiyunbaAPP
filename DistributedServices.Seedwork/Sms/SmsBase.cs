using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedServices.Seedwork.Sms
{
    public class SmsBase
    {
        private string m_SendUrl = null;
        private string m_errorMsg = null;

        private ParamRender m_SmsRender = new ParamRender();

        public SmsBase() { }

        public SmsBase(string mobile, string sendurl, string userKey, int tpl_id, string tpl_value, string dtype)
        {
            this.m_SendUrl = sendurl;
            this.m_SmsRender["key"] = userKey;
            this.m_SmsRender["mobile"] = mobile;
            this.m_SmsRender["tpl_id"] = tpl_id.ToString();
            this.m_SmsRender["tpl_value"] = tpl_value;
            this.m_SmsRender["dtype"] = dtype;
        }

        public virtual SmsSendServer.SendSmsResult Send()
        {
            SmsSendServer smsServer = new SmsSendServer();
            return smsServer.BeginSendSms(this);
        }

        public virtual ParamRender Render
        {
            get { return m_SmsRender; }
            set { m_SmsRender = value; }
        }

        public string ErrorMsg
        {
            get { return m_errorMsg; }
            set { m_errorMsg = value; }
        }

        public virtual string SendUrl
        {
            get { return m_SendUrl; }
            set { m_SendUrl = value; }
        }

    }
}
