using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.NetFramework.Logging
{
    
    class TraceListener : System.Diagnostics.TraceListener
    {

        public string FilePath { get; private set; }

        public TraceListener(string filePath)
        {
            FilePath = filePath;
        }

        public override void Write(string message)
        {
            WriteAsync(message, FilePath);
        }
        public override void WriteLine(string message)
        {

            WriteAsync(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss    ") + message + Environment.NewLine, FilePath);

        }
        public override void Write(object o, string category)
        {
            string message = string.Empty;
            if (!string.IsNullOrEmpty(category))
            {
                message = category + ":";
            }
            if (o is Exception)//如果参数对象o是与Exception类兼容,输出异常消息+堆栈,否则输出o.ToString()
            {
                var ex = (Exception)o;
                message += ex.Message + Environment.NewLine;
                message += ex.StackTrace;
            }
            else if (null != o)
            {
                message += o.ToString();
            }
            WriteAsync(message, FilePath);
        }


        public async Task WriteAsync(string message,string logPath)
        {
            var bits = Encoding.UTF8.GetBytes(message);
            using (var fs = new FileStream(
                path: logPath,
                mode: FileMode.Append,
                access: FileAccess.Write,
                share: FileShare.None,
                bufferSize: 4096,
                useAsync: true))
            {
                await fs.WriteAsync(bits, 0, bits.Length);
            }
        }

    }
}

