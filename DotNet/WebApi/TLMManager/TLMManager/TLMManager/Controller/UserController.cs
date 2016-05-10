using System.Collections.Generic;
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
        private readonly IUserService _service;
        public UserController()
        {
            _service = ModelInject.Inject<IUserService>();
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
            var list = _service.GetList();
 
            return list;
        }
    }
}
