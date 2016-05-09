using System.Collections.Generic;

#region 自有namespace
using TLMManager.Entity;
#endregion

namespace TLMManager.Service.Interface
{
    public interface IUserService
    {
        IDictionary<string, IList<SystemUser>> GetList();
    }
}
