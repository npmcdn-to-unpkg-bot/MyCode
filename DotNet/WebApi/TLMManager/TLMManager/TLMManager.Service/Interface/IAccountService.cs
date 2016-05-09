using TLMManager.Entity;

namespace TLMManager.Service.Interface
{
    public interface IAccountService
    {
        bool Logon(LogOnModel model, out string message, out SystemUser user);
    }
}
