using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface ICallLogAppService : IDisposable
    {

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="callLogDTO"></param>
        /// <returns></returns>
        CallLogDTO AddNewCallLog(CallLogDTO callLogDTO);

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        List<CallLogDTO> FindCallLogs(int pageIndex, int pageCount, Guid? sourceAccountId, out long total);

        /// <summary>
        /// delete a user info
        /// </summary>
        /// <param name="customerId"></param>
        void RemoveCallLog(Guid id);


    }
}
