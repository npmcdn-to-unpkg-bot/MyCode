using System.Web;
using System.Web.Http;
using TLMManager.Utils;

#region 自有namespace
using TLMManager.Entity;
using TLMManager.Service.Interface;
using TLMManager.Service;
#endregion

namespace TLMManager.Controller
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _service;

        public AccountController()
        {
            _service = ModelInject.Inject<IAccountService>();
        }   

        [HttpPost]
        public string Login([FromBody]LogOnModel login)
        {
            SystemUser user;
            string message;

            var isSuccess = _service.Logon(login, out message, out user);
            if (!isSuccess) return message;
            var authenService = new FormsAuthenticationWrapper();
            authenService.SetAuthCookie(HttpContext.Current, user, login.IsRemenberMe);
            return message;
        }

        [HttpGet]
        public string UserId()
        {
            var userId = CurrentUserId();
            return userId;
        }

    }
}
