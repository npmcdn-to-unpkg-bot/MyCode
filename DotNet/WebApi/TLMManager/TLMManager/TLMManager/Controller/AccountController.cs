using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        IAccountService service = null;

        public AccountController()
        {
            service = ModelInject.Inject<IAccountService>();
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
                isRemenberMe = isRemenberMe
            };
            bool isSuccess = service.Logon(model, out message, out user);
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
