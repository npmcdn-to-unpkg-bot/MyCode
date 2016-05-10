using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

#region 自用namespace
using TLMManager.Service.Interface;
using TLMManager.Service;
using TLMManager.Entity;
#endregion

namespace TLMManager.Controller
{
    public class MessageController : BaseController
    {
        private readonly IMessageService _service;
        private readonly IUserConnectionService _connService;
        public MessageController()
        {
            _service = ModelInject.Inject<IMessageService>();
            _connService = ModelInject.Inject<IUserConnectionService>();
        }

        /// <summary>
        /// 添加新的信息
        /// </summary>
        /// <param name="fromuser"></param>
        /// <param name="touser"></param>
        /// <param name="content"></param>
        public void Add(string fromuser, string touser, string content)
        {
            var message = new Message
            {
                FromUser = fromuser,
                ToUser = touser,
                Content = content,
                Flag = false,
                AddTime = DateTime.Now
            };
            _service.Add(message);
        }

        /// <summary>
        /// 获取聊天信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IDictionary<MessageUser, IList<Message>> GetMessages([FromBody]SystemUser user)
        {
            var list =
                _service.GetList(m => m.FromUser == user.UserName || m.ToUser == user.UserName)
                    .OrderByDescending(m => m.AddTime);
                    
            var messages = from m in list
                group m by new {m.FromUser, m.ToUser};

            var dic = new Dictionary<MessageUser, IList<Message>>();
            foreach (var item in messages)
            {
                var mUser = new MessageUser()
                {
                    ToUser = item.Key.ToUser,
                    FromUser = item.Key.FromUser
                };
                dic.Add(mUser, item.ToList());          
            }

            return dic;
        }

        /// <summary>
        /// 获取聊天列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IDictionary<string, MessageInfo> GetMessageList(string fromuser, string touser)
        {
            var list =
                _service.GetList(m => m.FromUser == fromuser || m.ToUser == touser)
                    .OrderByDescending(m => m.AddTime).ToList();

            var messages = from m in list
                           group m by new { m.FromUser, m.ToUser };

            var connList = _connService.GetList();
            var dic = new Dictionary<string, MessageInfo>();
            foreach (var item in messages)
            {
                var username = item.Key.FromUser == fromuser
                    ? item.Key.ToUser
                    : item.Key.FromUser;
                var conn = connList.FirstOrDefault(c => c.UserName == username);
                if (conn == null) continue;
                var singleOrDefault = item.FirstOrDefault();
                if (singleOrDefault == null) continue;
                var messageInfo = new MessageInfo()
                {
                    UserName = username,
                    Name = conn.Name,
                    Content = singleOrDefault.Content,
                    Avator = conn.Avator,
                    ConnectionId = conn.ConnectionId
                };
                dic.Add(username, messageInfo);
            }
            return dic;
        }
    }

}
