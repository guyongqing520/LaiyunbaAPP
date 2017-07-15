using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.WLModule.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{
    [RoutePrefix("area")]
    public class AreaController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IAreaAppService _areaAppService;
        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="areaAppService"></param>
        public AreaController(IAreaAppService areaAppService)
        {
            if (areaAppService == null)
                throw new ArgumentNullException("areaAppService");

            this._areaAppService = areaAppService;

        }

        #endregion

        // GET: api/Register
        public IHttpActionResult Get(string city)
        {
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException();

            var areas = this._areaAppService.FindAreas(city);

            if (areas == null)
                return NotFound();

            var newsArea = areas.Select(c => new { c.areaID, c.area, select = "" }).ToList();

            newsArea.Insert(0, new { areaID = 0, area = "全部区域", select = "select" });

            return Json<dynamic>(new { data = newsArea, total = newsArea.Count });

        }

    }
}

