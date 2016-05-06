using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLMManager.Entity;

namespace TLMManager.Service.Interface
{
    public interface IAccountService
    {
        bool Logon(LogOnModel model, out string message, out SystemUser user);
    }
}
