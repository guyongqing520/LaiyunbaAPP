using Application.MainBoundedContext.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainBoundedContext.WLModule.Services
{
    public interface IAccountAppService : IDisposable
    {
        AccountDTO AddNewAccount(AccountDTO userInfoDTO);
        void UpdateAccount(AccountDTO accountDTO);
        void RemoveAccount(Guid accountId);
        AccountDTO FindAccount(Guid accountId);
        AccountDTO FindAccount(string mobile);
        AccountDTO FindAccount(string mobile, string password, bool enable);
    }
}
