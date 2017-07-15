using DistributedServices.MainBoundedContext.Resources;
using Infrastructure.Crosscutting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace DistributedServices.MainBoundedContext.HandleError
{
    public class ApiHandleErrorAttribute: ExceptionFilterAttribute
    {
        /// <summary>
        /// 重写异常处理方法 add by caoheyang 20150205
        /// </summary>
        /// <param name="filterContext">上下文对象</param>
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            LoggerFactory.CreateLog().LogError(Messages.error_unmanagederror, filterContext.Exception);
        }
    }
}