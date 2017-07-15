using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace DistributedServices.MainBoundedContext.InstanceProviders
{
    public class UnityResolverContainer : IDependencyResolver
    {
        private IUnityContainer _container;
        public UnityResolverContainer(IUnityContainer container)
        {
            this._container = container;
        }
        public IDependencyScope BeginScope()
        {
            var scopeContainer = this._container.CreateChildContainer();
            return new UnityResolverContainer(scopeContainer);
        }
        /// <summary>
          /// 获取对应类型的实例，注意try...catch...不能够少
          /// </summary>
          /// <param name="serviceType"></param>
          /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                //if (!this._container.IsRegistered(serviceType)) { return null; }
                return this._container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }
        public void Dispose()
        {
            if (_container != null)
            {
                this._container.Dispose();
                this._container = null;
            }
        }
    }
}