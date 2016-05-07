using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
