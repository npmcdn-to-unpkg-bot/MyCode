using System.Web;
using System.Web.Http;
using System.Web.Security;

#region 自有namespace
using TLMManager.Entity;
using TLMManager.Service.Interface;
using TLMManager.Service;
using TLMManager.Utils;
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

        [AllowAnonymous]
        [HttpPost]
        public string Login(string username, string password, bool isRemenberMe)
        {
            SystemUser user;
            string message;
            LogOnModel model = new LogOnModel()
            {
                UserName = username, 
                PassWord = password,
                IsRemenberMe = isRemenberMe
            };
            bool isSuccess = _service.Logon(model, out message, out user);
            if (isSuccess)
            {
                FormsAuthenticationWrapper authenService = new FormsAuthenticationWrapper();
                authenService.SetAuthCookie(HttpContext.Current, user, isRemenberMe);
            }
            return message;
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }


    }
}
