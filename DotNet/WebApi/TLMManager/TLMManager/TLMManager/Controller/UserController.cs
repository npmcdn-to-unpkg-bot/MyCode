using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#region 自有namespace
using TLMManager.Entity;
using TLMManager.Service;
using TLMManager.Service.Interface;
#endregion
namespace TLMManager.Controller
{
    public class UserController : BaseController
    {

        IUserService service = null;
        public UserController()
        {
            service = ModelInject.Inject<IUserService>();
        }


        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <returns>
        /// dic
        /// <remarks>key:firstletter</remarks>
        /// <remarks>value:systemuser</remarks>
        /// </returns>
        [HttpGet]
        public IDictionary<string, IList<SystemUser>> GetList()
        {
            IDictionary<string, IList<SystemUser>> list = service.GetList();
            return list;
        }
    }
}
