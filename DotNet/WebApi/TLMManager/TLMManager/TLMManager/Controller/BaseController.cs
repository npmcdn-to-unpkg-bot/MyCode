﻿using System;
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
            return CurrentUser?.SystemUserId;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public SystemUser CurrentUser
        {
            get
            {
                var principal = User;
                if (principal == null)
                {
                    return null;
                }

                if (principal is SystemUser)
                {
                    return principal as SystemUser;
                }
                else
                {
                    return null;
                }
            }
        }



    }
}