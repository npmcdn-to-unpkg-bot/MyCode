using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TLMService
{
    public class TLMHub : Hub
    {
        private static readonly List<CurrentUser> ConnectedUsers = new List<CurrentUser>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="username"></param>
        public void Connect(string connectionId, string username)
        {
            var id = string.IsNullOrEmpty(connectionId) ? Context.ConnectionId : connectionId;
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new CurrentUser
                {
                    ConnectionId = id,
                    UserName = username
                });
                Clients.Caller.connect(id, username);

                //Clients.Client(id).onNewUserConnected(id, userID);
            }
            else
            {
                Clients.Caller.onConnected(id, username);
                //Clients.Client(id).onExistUserConnected(id, userID);
            }
            Console.WriteLine("id :" + id + "username :" + username + " connected");
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stopCalled"></param>
        public void LogOut(string username, bool stopCalled)
        {
            var id = Context.ConnectionId;

            OnDisconnected(stopCalled);
            Clients.Caller.onConnected(id, username);
            Clients.Client(id).onExit(id, username);

            Console.WriteLine("id :" + id + "username :" + username + " LogOut");
        }

        /// <summary>
        /// 覆盖
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);
            }
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="toUserName"></param>
        /// <param name="message"></param>
        public void Send(string toUserName, string message)
        {
            var toUser = ConnectedUsers.FirstOrDefault(x => x.UserName == toUserName);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

            if (toUser != null && fromUser != null)
            {
                Clients.Client(toUser.ConnectionId).send(fromUser.UserName, toUser.UserName, message);
                Clients.Caller.send(fromUser.UserName, toUser.UserName, message); ;
            }
            Console.WriteLine(" target:" + toUserName + "|message :" + message);
        }
    }
}
