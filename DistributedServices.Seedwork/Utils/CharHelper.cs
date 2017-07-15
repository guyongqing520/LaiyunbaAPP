using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DistributedServices.Seedwork.Utils
{
    public class CharHelper
    {

        static readonly string[] source ={"2","3","4","5","6","7","8","9",
            "a","b","c","d","e","f","h","j","k","m","n","p","r","s","t","u","v","w","x","y","z",
            "A","B","C","D","E","F","G","H","J","K","M","N","P","Q","R","S","T","U","V","W","X","Y","Z"};

        private static Random _random
        {
            get { return new Random(Environment.TickCount); }
        }

        /// <summary>
        /// 汉字转拼音缩写
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <returns>拼音缩写</returns>
        public static string GetPYString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }
        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        private static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "g";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }

        /// <summary>
        /// 产生code随机码
        /// </summary>
        /// <returns></returns>
        public static string RandCode(string code)
        {
            int[] r = GetRandNumber8();
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            for (int i = 0; i < r.Length; i++)
            {
                str.Append(code[r[i]]);
            }
            return str.ToString();
        }

        /// <summary>
        /// 产生种子器-随机生成数组下标(8位)
        /// </summary>
        /// <returns></returns>
        public static int[] GetRandNumber8()
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7 };
            ArrayList arraylist = new ArrayList(array);

            int[] index = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int r = _random.Next(arraylist.Count);
                index[i] = (int)arraylist[r];
                arraylist.RemoveAt(r);
            }
            return index;
        }

        public static int Number(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        /// <summary>
        /// 产生随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = Number(0, source.Length - 1);
                s.Append(source[index]);
            }

            return s.ToString();
        }

        /// <summary>  
        /// List<T>随机排序  
        /// </summary>  
        /// <typeparam name="T">T</typeparam>  
        /// <param name="list">待随机排序的list</param>  
        /// <returns>随机排序的newlist</returns>  
        public static List<T> ToRandomSort<T>(List<T> list)
        {
            Random random = new Random();
            List<T> newList = new List<T>();

            foreach (T item in list)
            {
                newList.Insert(random.Next(newList.Count), item);
            }

            return newList;
        }

        //随机打乱数组
        public static void AarryRandom<T>(ref T[] arr)
        {
            if (arr.Length <= 0)
                return;

            Random ran = new Random();
            int k = 0;
            T strtmp;
            for (int i = 0; i < arr.Length; i++)
            {
                k = ran.Next(0, arr.Length);
                if (k != i)
                {
                    strtmp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = strtmp;
                }
            }

        }

        /// <summary>
        /// 生成随机手机验证码，Length位
        /// </summary>
        /// <returns></returns>
        public static string GetRandomSmsCode(int Length)
        {
            if (Length <= 0)
                return String.Empty;

            Random random = new Random();
            StringBuilder sign = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                sign.Append(random.Next(0, 9));
            }
            return sign.ToString();
        }

        #region  验证身份证号码

        /// <summary>
        /// 验证身份证号码
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckIDCard18(string Id)
        {
            long n = 0;

            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace("x", "0").Replace("X", "0"), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(new char[] { ',' });
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(new char[] { ',' });
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        #region 加密方法

        /// <summary>
        /// MD5加密方法
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <param name="type">加密类型，32位</param>
        /// <returns>加密后的MD5串</returns>
        public static string GetMD5(string str)
        {
            if (object.Equals(str, null)) { return ""; }
            byte[] b = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            b = md5.ComputeHash(b);
            string result = BitConverter.ToString(b);

            return result.Replace("-", "");
        }

        /// <summary>
        /// MD5加密方法,UTF8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5_UTF8(string str)
        {
            if (object.Equals(str, null)) { return ""; }
            byte[] b = Encoding.UTF8.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            b = md5.ComputeHash(b);
            string result = BitConverter.ToString(b);

            return result.Replace("-", "");
        }


        public static string MD5(string Password, int Length)
        {
            if (string.IsNullOrEmpty(Password))
                return "";

            if (Length != 16 && Length != 32) throw new System.ArgumentException("Length参数无效,只能为16位或32位");
            System.Security.Cryptography.MD5CryptoServiceProvider MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] b = MD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            System.Text.StringBuilder StrB = new System.Text.StringBuilder();
            for (int i = 0; i < b.Length; i++)
                StrB.Append(b[i].ToString("x").PadLeft(2, '0'));
            if (Length == 16)
                return StrB.ToString(8, 16);
            else
                return StrB.ToString();
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSHA1(string str)
        {
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1");

            byte[] cleanBytes = Encoding.Default.GetBytes(str);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSHA256(string str)
        {
            System.Security.Cryptography.SHA256 s256 = new System.Security.Cryptography.SHA256Managed();
            byte[] byte1;
            byte1 = s256.ComputeHash(Encoding.Default.GetBytes(str));
            s256.Clear();
            return Convert.ToBase64String(byte1);
        }


       
        #endregion

        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static int GetStringCount(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return 0;
            return Encoding.Default.GetByteCount(Text);
        }


        /// <summary>
        /// 拼接queryString quertString="{name:se,admin:ga}";
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static NameValueCollection GetJsonQueryList(string queryString)
        {
            NameValueCollection tempUrl = new NameValueCollection();
            if (string.IsNullOrEmpty(queryString))
                return null;

            queryString = queryString.Replace("{", "").Replace("}", "");

            if (string.IsNullOrEmpty(queryString))
                return null;

            if (queryString.IndexOf(",") != -1)
            {
                var queryArray = queryString.Split(',');
                foreach (var item in queryArray)
                {
                    if (item.IndexOf(":") != -1 && item.Split(':').Length != 2)
                        return null;
                    else
                    {
                        for (int i = 0; i < item.Split(':').Length; i++)
                        {
                            tempUrl.Add(item.Split(':')[0], item.Split(':')[1]);
                        }
                    }
                }
            }
            else
            {
                if (queryString.IndexOf(":") != -1 && queryString.Split(':').Length != 2)
                    return null;
                else
                {
                    for (int i = 0; i < queryString.Split(':').Length; i++)
                    {
                        tempUrl.Add(queryString.Split(':')[0], queryString.Split(':')[1]);
                    }
                }
            }
            return tempUrl;
        }

        /// <summary>
        /// {"a":"10","b":"100"}
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<string> GetValueFromJson(string json)
        {
            List<string> data = new List<string>();
            string tempStr = json.Replace("{", "").Replace("}", "");
            string[] tempStrArray = tempStr.Split(',');
            foreach (var item in tempStrArray)
            {
                data.Add(item.Split(':')[1].ToString());
            }

            return data;
        }

       

        public static IDictionary<string, string> GetLookupTable(string xmlContents)
        {
            return XElement.Parse(xmlContents)
                           .Elements()
                           .ToDictionary(x => x.Name.LocalName,
                                         x => x.Value);
        }


        public static string SubString(string inputString, int length)
        {
            if (Encoding.UTF8.GetByteCount(inputString) <= length * 2)
            {
                return inputString;
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
                tempString += inputString.Substring(i, 1);
                if (tempLen >= (length - 1) * 2)
                    break;
            }
            //如果截过则加上半个省略号  
            if (System.Text.Encoding.Default.GetBytes(inputString).Length > length)
                tempString += "...";
            return tempString;
        }

    }
}
