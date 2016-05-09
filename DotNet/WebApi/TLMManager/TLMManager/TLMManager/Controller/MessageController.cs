using System;
using System.Collections.Generic;

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
        public MessageController()
        {
            _service = ModelInject.Inject<IMessageService>();
        }

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

        public IList<Message> GetList()
        {
            var list = _service.GetList();
            return list;
        }
    }
}
