using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using DistributedServices.Seedwork.Utils;

namespace DistributedServices.Seedwork.Sms
{
    public class SmsSendServer
    {

        public enum SendSmsResult
        {
            Fail = 0, //失败
            Success = 1//成功
        }

        public SmsSendServer()
        {
            this.IsNew = true;
        }
        public SendSmsResult BeginSendSms(SmsBase sms)
        {
            return DoBeginSendMail(sms);
            //WaitCallback callback = new WaitCallback(DoBeginSendMail);
            //bool result = ThreadPool.QueueUserWorkItem(callback, sms);

        }
        private SendSmsResult DoBeginSendMail(object smsObject)
        {
            SmsBase sms = smsObject as SmsBase;

            if (sms == null)
                return SendSmsResult.Fail;

            return SendSms(sms);
        }
        public SendSmsResult SendSms(SmsBase sms)
        {
            try
            {
                var paramsUrlStr = UrlHelper.BuildQuery(sms.Render.ReplaceVariables, "utf8");
                var getUrl = sms.SendUrl + "?" + paramsUrlStr;
                var getString = UrlHelper.HttpGet(getUrl);
                //var getString = "";

                var xmlContents = CharHelper.GetLookupTable(getString);

                foreach (KeyValuePair<string, string> kv in xmlContents)
                {

                    if (kv.Key.Equals("reason") && kv.Value.Equals("操作成功"))
                        return SendSmsResult.Success;
                    else
                    {
                        sms.ErrorMsg = kv.Value;
                        return SendSmsResult.Fail;
                    }

                }
                return SendSmsResult.Fail;
            }
            catch
            {
                return SendSmsResult.Fail;
            }
        }

        #region IBatchSave 成员

        public bool IsNew
        {
            get;
            set;
        }

        #endregion
    }
}
