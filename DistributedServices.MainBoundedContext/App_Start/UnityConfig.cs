using Application.MainBoundedContext.WLModule.Services;
using DistributedServices.MainBoundedContext.InstanceProviders;
using Domain.MainBoundedContext.WLModule.Aggregates.AccountAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.AddressAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.CallLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.DriverWayAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.FavoriteAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.LoginLogAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.MsgAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.PraiseAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.SmsAgg;
using Domain.MainBoundedContext.WLModule.Aggregates.VipAgg;
using Infrastructure.Crosscutting.Adapter;
using Infrastructure.Crosscutting.Logging;
using Infrastructure.Crosscutting.NetFramework.Adapter;
using Infrastructure.Crosscutting.NetFramework.Logging;
using Infrastructure.Crosscutting.NetFramework.Validator;
using Infrastructure.Crosscutting.Validator;
using Infrastructure.Data.MainBoundedContext.UnitOfWork;
using Infrastructure.Data.MainBoundedContext.WLModule.Repositories;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;

namespace DistributedServices.MainBoundedContext
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var _currentContainer = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //-> Unit of Work and repositories
            _currentContainer.RegisterType(typeof(MainBCUnitOfWork), new PerResolveLifetimeManager());

            _currentContainer.RegisterType<IAccountRepository, AccountRepository>();
            _currentContainer.RegisterType<ICallLogRepository, CallLogRepository>();

            _currentContainer.RegisterType<IDriverWayRepository, DriverWayRepository>();
            _currentContainer.RegisterType<IFavoriteRepository, FavoriteRepository>();

            _currentContainer.RegisterType<ILoginLogRepository, LoginLogRepository>();
            _currentContainer.RegisterType<IMsgRepository, MsgRepository>();

            _currentContainer.RegisterType<ILoginLogRepository, LoginLogRepository>();
            _currentContainer.RegisterType<IPraiseRepository, PraiseRepository>();

            _currentContainer.RegisterType<ISmsRepository, SmsRepository>();
            _currentContainer.RegisterType<IVipRepository, VipRepository>();

            _currentContainer.RegisterType<ICityRepository, CityRepository>();
            _currentContainer.RegisterType<IAreaRepository, AreaRepository>();
            _currentContainer.RegisterType<IProvinceRepository, ProvinceRepository>();


            //-> Adapters
            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            //-> Domain Services
            //-> Application services
            _currentContainer.RegisterType<IAccountAppService, AccountAppService>();
            _currentContainer.RegisterType<ICallLogAppService, CallLogAppService>();

            _currentContainer.RegisterType<IFavoriteAppService, FavoriteAppService>();
            _currentContainer.RegisterType<ILoginLogAppService, LoginLogAppService>();

            _currentContainer.RegisterType<IMsgAppService, MsgAppService>();
            _currentContainer.RegisterType<IPraiseAppService, PraiseAppService>();

            _currentContainer.RegisterType<IProudctAppService, ProudctAppService>();
            _currentContainer.RegisterType<ISmsAppService, SmsAppService>();

            _currentContainer.RegisterType<ISpecwayAppService, SpecwayAppService>();
            _currentContainer.RegisterType<IVipAppService, VipAppService>();

            _currentContainer.RegisterType<IAreaAppService, AreaAppService>();


            // e.g. container.RegisterType<ITestService, TestService>();

            RegisterConfigureFactories(_currentContainer);

            GlobalConfiguration.Configuration.DependencyResolver =new UnityResolverContainer(_currentContainer);


        }


        static void RegisterConfigureFactories(IUnityContainer currentContainer)
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }
    }
}