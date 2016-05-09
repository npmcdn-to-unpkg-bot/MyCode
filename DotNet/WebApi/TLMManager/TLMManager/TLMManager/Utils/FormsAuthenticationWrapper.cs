using System;
using System.Web;
using System.Web.Security;

#region 自有namespace
using TLMManager.Entity;
#endregion

namespace TLMManager.Utils
{
    public class FormsAuthenticationWrapper 
    {
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public void SetAuthCookie(HttpContext context, SystemUser user, bool createPersistentCookie)
        {
            const int cookieExpiration = 7; //Cookie过期日期
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            //把需要保存的用户数据转换成字符串
            //string userData = (new JavaScriptSerializer()).Serialize(user);

            var ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddDays(cookieExpiration), createPersistentCookie, "");
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            //根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            if (createPersistentCookie)
            {
                cookie.Expires = DateTime.Now.AddDays(cookieExpiration);
            }

            //写Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }
    }
}
