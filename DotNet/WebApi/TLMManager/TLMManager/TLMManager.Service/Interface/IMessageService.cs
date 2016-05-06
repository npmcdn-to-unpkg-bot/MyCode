using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;	

#region 自有namespace
using TLMManager.Entity;
	 
#endregion


namespace TLMManager.Service.Interface
{
    public interface IMessageService 
    {
        /// <summary>
        /// 根据fromuser, touser, addtime得到实体
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Message Find(string fromUser, string toUser, DateTime addtime);

        bool Add(Message message);

        IList<Message> GetList();

        IList<Message> GetList(Expression<Func<Message, bool>> factor);
    }
}
