using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.Seedwork.Utils;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Net.Http;
using System.Net;
using System;
using System.Drawing;
using System.Web;
using DistributedServices.MainBoundedContext.Resources;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("upload")]
    public class UploadController : ApiController
    {
        public Task<dynamic> Post()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            string dirTempPath = GetMapPath(string.Format("~/Content/images/upload/{0}/", DateTime.Now.ToString("yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo)));

            if (!System.IO.Directory.Exists(dirTempPath))
                System.IO.Directory.CreateDirectory(dirTempPath);

            var provider = new MultipartFormDataStreamProvider(dirTempPath);

            var task = Request.Content.ReadAsMultipartAsync(provider).
                    ContinueWith<dynamic>(o =>
                    {

                        var file = provider.FileData[0];
                        var action = provider.FormData["Action"];
                        var accountId = provider.FormData["AccountId"];

                        try
                        {
                            if (string.IsNullOrEmpty(accountId))
                                return Ok<string>(Messages.error_ValidateUserLoging);

                            string orfilename = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                            FileInfo fileinfo = new FileInfo(file.LocalFileName);

                            int maxSize = 10240000;//10M

                            if (fileinfo.Length <= 0)
                                return Ok<string>(Messages.error_ValidateNotUpLoadFile);


                            if (fileinfo.Length > maxSize)
                                return Ok<string>(Messages.error_ValidateUpLoadFileTooBig);

                            string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));

                            String fileTypes = "gif,jpg,jpeg,png,bmp";

                            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                                return Ok<string>(Messages.error_ValidateUpLoadFileNotAllowFx);


                            String ymd = DateTime.Now.ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            Random random = new Random();
                            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff", System.Globalization.DateTimeFormatInfo.InvariantInfo) + random.Next(10).ToString();

                            fileinfo.MoveTo(Path.Combine(dirTempPath, newFileName + fileExt));

                            var url = CreateMinImageAndDel(Path.Combine(dirTempPath, newFileName + fileExt), dirTempPath, 440, 260);

                            return Json<dynamic>(new { data = new { action = action, url = url } });

                        }
                        catch (Exception ex)
                        {
                            return Json<dynamic>(new { data = new { action = action, ex = ex } });
                        }
                    });

            return task;
        }

        public string CreateMinImageAndDel(string originalImagePath, string thumbnailPath, int width, int height)
        {
            Graphics draw = null;
            string FileExt = string.Empty;

            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            //按照宽度自动缩放
            int towidth = originalImage.Width < width ? originalImage.Width : width;
            int auto = Convert.ToInt32(originalImage.Width / towidth);//缩放比例
            int toheight = Convert.ToInt32(originalImage.Height / auto);

            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //高并发时为了不让I/O出现异常
            System.Drawing.Image bitmap2 = new System.Drawing.Bitmap(towidth, toheight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight));

            //绘制logo水印
            System.Drawing.Image logo = System.Drawing.Image.FromFile(GetMapPath("~/Content/themes/default/images/avatars/shuiyin.png"));//加载logo图片
            if (bitmap.Width > logo.Width && bitmap.Height > logo.Height)
            {

                float rectWidth = (float)logo.Width;
                float rectHeight = (float)logo.Height;
                float rectX = bitmap.Width - rectWidth;
                float rectY = bitmap.Height - rectHeight;

                RectangleF textArea = new RectangleF(rectX - 12, rectY - 12, rectWidth, rectHeight);
                g.DrawImage(logo, textArea);

            }

            try
            {
                //保存缩略图
                FileExt = Path.GetFileName(originalImagePath);
                //用新建立的image对象拷贝bitmap对象 让g对象可以释放资源
                draw = Graphics.FromImage(bitmap2);
                draw.DrawImage(bitmap, 0, 0);

            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();

                bitmap2.Save(thumbnailPath + FileExt, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            return GetUrlConvertor(thumbnailPath + FileExt);
        }

        private string GetUrlConvertor(string imagesurl1)
        {
            string tmpRootDir = string.Empty;//获取程序根目录


            if (HttpContext.Current != null)
            {
                tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
            }
            else //非web程序引用
            {
                tmpRootDir = AppDomain.CurrentDomain.BaseDirectory;
            }

            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            return "/" + imagesurl2;
        }

        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                strPath = strPath.Substring(strPath.IndexOf('\\') + 1);

                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
    }
}

