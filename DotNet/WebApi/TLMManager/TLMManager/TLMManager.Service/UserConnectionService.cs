using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TLMManager.Core;
using TLMManager.Entity;
using TLMManager.Service.Interface;

namespace TLMManager.Service
{
    public class UserConnectionService : IUserConnectionService
    {
        private readonly IDbHelper _db;
        public UserConnectionService()
        {
            _db = DbHelperInject.Inject<IDbHelper>(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserConnection Get(string username)
        {
            var model = _db.Find<UserConnection>(c => c.UserName == username);
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public bool Add(UserConnection conn)
        {
            conn.Id = Guid.NewGuid();
            _db.Add(conn);
            return _db.Save() > 0;
        }

        public IList<UserConnection> GetList()
        {
            return _db.GetList<UserConnection>().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public IList<UserConnection> GetList(Expression<Func<UserConnection, bool>> factor)
        {
            return _db.GetList(factor).ToList();
        }
    }
}
