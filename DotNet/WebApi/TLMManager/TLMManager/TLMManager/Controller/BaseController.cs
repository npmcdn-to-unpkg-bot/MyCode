using System;
using System.Collections.Generic;
using System.Linq;
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
            if (this.CurrentUser != null)
            {
                return this.CurrentUser.SystemUserId;
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
                var principal = this.User;
                if (principal == null)
                {
                    return null;
                }

                if (principal is SystemUser)
                {
                    return (SystemUser)principal;
                }
                else
                {
                    return null;
                }
            }
        }



    }
}