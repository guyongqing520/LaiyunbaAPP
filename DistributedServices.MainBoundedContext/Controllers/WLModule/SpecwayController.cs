using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.WLModule.Services;
using Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg;
using Domain.Seedwork.Specification;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq.Expressions;
using System.Web.Http;
using System.Linq;
using DistributedServices.MainBoundedContext.Resources;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;

namespace DistributedServices.MainBoundedContext.Controllers.WLModule
{

    [RoutePrefix("specway")]
    public class SpecwayController : ApiController
    {
        /// <summary>
        /// Constructors ioc members
        /// </summary>
        #region Members

        readonly IAccountAppService _accountAppService;
        readonly ISpecwayAppService _specwayAppService;
        readonly IMsgAppService _msgAppService;
        readonly IVipAppService _vipAppService;


        Func<float, float, float, float, double?> DistanceFun = (float sourceLng, float sourceLat, float destLng, float destLay) =>
        {
            return DbGeography.FromText(string.Format("POINT({0} {1})", sourceLng, sourceLat)).Distance(DbGeography.FromText(string.Format("POINT({0} {1})", destLng, destLay)));
        };


        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance RegisterController api
        /// </summary>
        /// <param name="accountAppService"></param>
        /// <param name="smsAppService"></param>
        /// <param name="msgAppService"></param>
        /// <param name="vipAppService"></param>
        public SpecwayController(IAccountAppService accountAppService, ISpecwayAppService specwayAppService, IMsgAppService msgAppService, IVipAppService vipAppService)
        {
            if (accountAppService == null)
                throw new ArgumentNullException("accountAppService");

            if (specwayAppService == null)
                throw new ArgumentNullException("specwayAppService");

            if (msgAppService == null)
                throw new ArgumentNullException("msgAppService");

            if (vipAppService == null)
                throw new ArgumentNullException("vipAppService");

            this._accountAppService = accountAppService;
            this._specwayAppService = specwayAppService;
            this._msgAppService = msgAppService;
            this._vipAppService = vipAppService;

        }

        #endregion

        // GET: api/specway
        public IHttpActionResult Get(int pageNo, int pageSize, string sc, string dc, string sa, string te, string scope, string keyWord, bool isAudite = false, float lng = 0, float lat = 0, string name = "")
        {

            long total = 0;
            Expression<Func<Specway, bool>> filter = u => u.IsEnabled;
            Expression<Func<Specway, dynamic>> orderByExpression = u => u.HeadUrl;

            bool ascending = true;

            if (!String.IsNullOrEmpty(name))
                filter = filter.And(u => u.Name.Contains(name));

            if (!String.IsNullOrEmpty(sc))
                filter = filter.And(u => u.SourcePrivince.Contains(sc) || u.SourceCity.Contains(sc));

            if (!String.IsNullOrEmpty(sa))
                filter = filter.And(u => u.SourceArea.Contains(sa) || u.SourceCity.Contains(sa));

            if (!String.IsNullOrEmpty(dc))
                filter = filter.And(u => u.DestCity.Contains(dc) || u.DestCity1.Contains(dc) || u.DestCity2.Contains(dc));

            if (!String.IsNullOrEmpty(keyWord))
                filter = filter.And(u => u.Name.Contains(keyWord) || u.SourceAddress.Contains(keyWord));

            if (scope == "1")
                filter = filter.And(u => u.DestCity.Length > 4);

            if (scope == "2")
                filter = filter.And(u => u.DestCity.Length <= 4);

            if (scope == "3" && lng > 0 && lat > 0)
                orderByExpression = u => DistanceFun(u.Lng, u.Lat, lng, lat);

            if (te == "1")
                orderByExpression = u => u.LateDate;

            else
                orderByExpression = u => DistanceFun(u.Lng, u.Lat, lng, lat);

            if (isAudite)
                return Json<dynamic>(new { data = _specwayAppService.FindSpecways(pageNo, pageSize, u => true, u => u.CrateOn, true, out total), total = total });

            var specways = _specwayAppService.FindSpecways(pageNo, pageSize, filter, orderByExpression, ascending, out total);

            long viptotal = 0;

            return Json<dynamic>(new
            {
                data = specways.Select(s => new
                {
                    s,
                    Vip = _vipAppService.FindVips(1, 1, s.AccountId, out viptotal).Count,
                    Distance = DistanceFun(s.Lng, s.Lat, lng, lat)
                }),
                total = total
            });
        }

        // GET: api/specway/5
        public IHttpActionResult Get(Guid id, float lng = 0, float lat = 0)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var wayDTO = _specwayAppService.FindSpecway(id);

            if (wayDTO == null)
                return NotFound();

            wayDTO.ViewCount++;

            this._specwayAppService.UpdateSpecway(wayDTO);


            return Json<dynamic>(
                new
                {
                    data = new
                    {
                        wayDTO,
                        IsVip = _vipAppService.FindVip(wayDTO.AccountId) == null ? "No" : "Yes",
                        Distance = DistanceFun(wayDTO.Lng, wayDTO.Lat, lng, lat)
                    },
                    total = 1
                });
        }


        public IHttpActionResult Post([FromBody] SpecwayDTO specDTO)
        {
            if (specDTO == null || specDTO.AccountId == Guid.Empty)
                throw new ArgumentException();

            var accountDTO = this._accountAppService.FindAccount(specDTO.AccountId);

            if (accountDTO == null)
                return Ok(Messages.error_ValidateUserLoging);

            if (!accountDTO.IsEnabled)
                return Ok(Messages.error_ValidateMobileFreeze);

            if (accountDTO.UserType == (int)UserType.CarUser)
                return Ok(Messages.error_ValidateCarUser);

            //get lng and lat
            float lat = 0, lng = 0;

            if (new AddressController().Get(specDTO.SourceAddress, out lng, out lat))
            {
                specDTO.Lng = lng;
                specDTO.Lat = lat;
            }

            var resultSpectWayDTO = this._specwayAppService.AddNewSpecway(specDTO);

            if (resultSpectWayDTO == null)
                throw new NotImplementedException();

            return Ok();
        }

        // PUT: api/specway/5
        public IHttpActionResult Put(string action, Guid adminId, [FromBody] SpecwayDTO specDTO)
        {

            if (specDTO.Id == Guid.Empty || string.IsNullOrEmpty(action))
                throw new ArgumentException();

            if (action == "vipReflus")
            {

                var accountDTO = this._accountAppService.FindAccount(specDTO.AccountId);

                if (accountDTO == null)
                    return Ok(Messages.error_ValidateUserLoging);

                if (!accountDTO.IsEnabled)
                    return Ok(Messages.error_ValidateMobileFreeze);

                if (accountDTO.UserType == (int)UserType.CarUser)
                    return Ok(Messages.error_ValidateCarUser);


                if (specDTO == null)
                    return NotFound();

                var vipDTO = _vipAppService.FindVip(specDTO.AccountId);

                if (vipDTO == null || vipDTO.EndDateTime < DateTime.Now)
                    return Ok<string>(Messages.error_ValidateNotVIPReflus);

                specDTO.LateDate = DateTime.Now;

                _specwayAppService.UpdateSpecway(specDTO);

                return Ok();
            }
            else if (action == "adminAudite")
            {
                var adminDto = this._accountAppService.FindAccount(adminId);

                if (adminDto == null || adminDto.UserType != 2)
                    return Ok<string>(Messages.error_ValidateNotAdmin);

                specDTO.IsEnabled = !specDTO.IsEnabled;

                this._specwayAppService.UpdateSpecway(specDTO);

                return Ok();
            }
            else if (action == "userEdit")
            {
                if (specDTO == null)
                    return NotFound();

                var accountDTO = this._accountAppService.FindAccount(specDTO.AccountId);

                if (accountDTO == null)
                    return Ok(Messages.error_ValidateUserLoging);

                if (!accountDTO.IsEnabled)
                    return Ok(Messages.error_ValidateMobileFreeze);

                if (accountDTO.UserType == (int)UserType.CarUser)
                    return Ok(Messages.error_ValidateCarUser);

                specDTO.IsEnabled = false;

                this._specwayAppService.UpdateSpecway(specDTO);

                return Ok();

            }

            throw new ArgumentNullException();
        }
    }

}

