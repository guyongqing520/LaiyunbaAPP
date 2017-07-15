using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Seedwork;
using Infrastructure.Crosscutting.Validator;
using Infrastructure.Crosscutting.Logging;
using Domain.MainBoundedContext.WLModule.Aggregates.AddressAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class AreaAppService :
        IAreaAppService
    {

        #region Members

        readonly IAreaRepository _areaRepository;
        readonly ICityRepository _cityRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of Praise Management Service
        /// </summary>
        /// <param name="favoriteRepository">Associated smsRepository, intented to be resolved with DI</param>
        public AreaAppService(IAreaRepository areaRepository, ICityRepository cityRepository) //the userinfo repository                   
        {

            if (areaRepository == null)
                throw new ArgumentNullException("areaRepository");

            if (cityRepository == null)
                throw new ArgumentNullException("cityRepository");

            _areaRepository = areaRepository;
            _cityRepository = cityRepository;

        }


        #endregion


        #region PraiseRepository Members



        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<AreaDTO> FindAreas(string city)
        {

            IEnumerable<Area> list=null;

            switch (city)
            {
                case "北京":
                    list= this._areaRepository.GetFiltered(a => a.father.Equals("110100") || a.father.Equals("110200")).Where(a => !a.area.Equals("市辖区"));
                    break;

                case "天津":
                    list= this._areaRepository.GetFiltered(a => a.father.Equals("120100") || a.father.Equals("120200")).Where(a => !a.area.Equals("市辖区"));
                    break;

                case "上海":
                    list= this._areaRepository.GetFiltered(a => a.father.Equals("310100") || a.father.Equals("310200")).Where(a => !a.area.Equals("市辖区"));
                    break;

                case "重庆":
                    list= this._areaRepository.GetFiltered(a => a.father.Equals("500100") || a.father.Equals("500200") || a.father.Equals("500200")).Where(a => !a.area.Equals("市辖区"));
                    break;

                default:
                    var cityCode = _cityRepository.GetFiltered(c => c.city.Contains(city)).FirstOrDefault();
                    if (cityCode == null)
                        return null;
                    list= this._areaRepository.GetFiltered(a => a.father.Equals(cityCode.cityID.ToString())).Where(a => !a.area.Equals("市辖区"));
                    break;
            }

            //recover praise
   
            if (list != null
                &&
                list.Any())
            {
                return list.ProjectedAsCollection<AreaDTO>();
            }
            else // no data.
                return null;
        }


        #endregion

        #region Private Methods


        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _areaRepository.Dispose();
        }

        #endregion

    }
}
