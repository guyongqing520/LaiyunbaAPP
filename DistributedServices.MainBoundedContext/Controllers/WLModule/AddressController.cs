using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.Seedwork.Utils;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("address")]
    public class AddressController : ApiController
    {

        public IHttpActionResult Get(string location)
        {

            var queryRouteUrl = string.Format("http://apis.map.qq.com/ws/geocoder/v1/?location={0}&key=T6EBZ-KHCWX-TKE46-7AT6P-PFYHO-HTF3W&get_poi=1", location);
            var contextXMLRoute = UrlHelper.HttpGet(queryRouteUrl);

            JObject o = JObject.Parse(contextXMLRoute);

            if (o["status"] != null && o["status"].ToString() == "0")
                return Json<dynamic>(new { data = o["result"], total = 1 });

            return NotFound();
        }

        public IHttpActionResult Get(string address, string city)
        {
            var queryRouteUrl = string.Format("http://apis.map.qq.com/ws/geocoder/v1/?address={0}&key=T6EBZ-KHCWX-TKE46-7AT6P-PFYHO-HTF3W", address, city);
            var contextXMLRoute = UrlHelper.HttpGet(queryRouteUrl);

            JObject o = JObject.Parse(contextXMLRoute);

            if (o["status"] != null && o["status"].ToString() == "0")
                return Json<dynamic>(new { data = o["result"], total = 1 });

            return NotFound();
        }

        internal bool Get(string address, out float lng, out float lat)
        {
            lng = 0;
            lat = 0;

            var queryRouteUrl = string.Format("http://apis.map.qq.com/ws/geocoder/v1/?address={0}&key=T6EBZ-KHCWX-TKE46-7AT6P-PFYHO-HTF3W", address);
            var contextXMLRoute = UrlHelper.HttpGet(queryRouteUrl);

            JObject o = JObject.Parse(contextXMLRoute);

            if (o["status"] != null && o["status"].ToString() == "0")
            {
                lng = (float)o["result"]["location"]["lng"];
                lat = (float)o["result"]["location"]["lat"];
                return true;
            }

            return false;
        }


    }
}

