using AutoMapper;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.AddressAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.CallLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.FavoriteAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.MsgAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.PraiseAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.ProductAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.VipAgg;
using System.Data.Entity.Spatial;


namespace Application.MainBoundedContext.DTO.Profiles
{
    class WlProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Account, AccountDTO>();

            Mapper.CreateMap<CallLog, CallLogDTO>();
            Mapper.CreateMap<DriverWay, DriverWayDTO>();

            Mapper.CreateMap<Favorite, FavoriteDTO>();
            Mapper.CreateMap<LoginLog, LoginLogDTO>();

            Mapper.CreateMap<Msg, MsgDTO>();
            Mapper.CreateMap<Praise, PraiseDTO>();

            Mapper.CreateMap<Sms, SmsDTO>();
            Mapper.CreateMap<GooderProudct, GooderProudctDTO>();

            Mapper.CreateMap<Specway, SpecwayDTO>();
            Mapper.CreateMap<Vip, VipDTO>();

            Mapper.CreateMap<City, CityDTO>();
            Mapper.CreateMap<Area, AreaDTO>();
            Mapper.CreateMap<Province, ProvinceDTO>();

        }
    }

}

