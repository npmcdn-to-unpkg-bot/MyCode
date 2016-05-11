using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using TLMManager.Entity;

namespace TLMManager.Controller
{
    /// <summary>
    /// 基类
    /// </summary>
    public abstract class BaseController : ApiController
    {
        //<summary>
        //获取当前用户ID
        //</summary>
        //<returns></returns>
        protected string CurrentUserId()
        {
            return CurrentUser != null ? CurrentUser.UserName : null;
        }

        //<summary>
         //当前用户
         //</summary>
        protected SystemUser CurrentUser
        {
            get
            {
                var principal = User;

                if (principal is SystemUser)
                {
                    return principal as SystemUser;
                }
                return null;
            }
        }

        protected void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }



    }
}