using System;
using System.Web.Http;
using TLMManager.Entity;

namespace TLMManager.Controller
{
    /// <summary>
    /// 基类
    /// </summary>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// 获取当前用户ID
        /// </summary>
        /// <returns></returns>
        public Guid? CurrentUserId()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.SystemUserId;
            }
            return null;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public SystemUser CurrentUser
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



    }
}