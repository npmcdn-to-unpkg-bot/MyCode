using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        IMessageService service = null;
        public MessageController()
        {
            service = ModelInject.Inject<IMessageService>();
        }

        public void Add(string fromuser, string touser, string content)
        {
            Message message = new Message
            {
                FromUser = fromuser,
                ToUser = touser,
                Content = content,
                Flag = false,
                AddTime = DateTime.Now
            };
            service.Add(message);
        }
    }
}
