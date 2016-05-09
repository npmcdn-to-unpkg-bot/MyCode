using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#region 自用namespace
using TLMManager.Core;
using TLMManager.Entity;
using TLMManager.Service.Interface;

#endregion

namespace TLMManager.Service
{
    public class MessageService : IMessageService  
    {
        private readonly IDbHelper _db;

        public MessageService() 
        { 
            _db = DBHelperInject.Inject<IDbHelper>(); 
        }

        #region IMessageService Members

        /// <summary>
        /// 根据fromuser, touser, addtime得到实体
        /// </summary>
        /// <param name="fromUser"></param>
        /// <param name="toUser"></param>
        /// <param name="addtime"></param>
        /// <returns></returns>
        public Message Find(string fromUser, string toUser, DateTime addtime)
        {
            return _db.Find<Message>(m => m.FromUser == fromUser && m.ToUser == toUser && m.AddTime == addtime);
        }

        public bool Add(Message message)
        {
            message.Id = Guid.NewGuid();
            _db.Add(message);
            return _db.Save() > 0;
        }

        public IList<Message> GetList()
        {
            return _db.GetList<Message>().ToList();
        }

        public IList<Message> GetList(Expression<Func<Message, bool>> factor)
        {
            return _db.GetList(factor).ToList();
        }


        #endregion
    }
}
