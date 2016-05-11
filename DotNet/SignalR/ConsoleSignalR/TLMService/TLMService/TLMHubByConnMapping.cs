using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TLMService
{
    public class TLMHubByConnMapping : Hub
    {
        private static readonly ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="connectionId"></param>
        public void Connect(string username, string connectionId)
        {
            var id = connectionId.Length > 0 ? connectionId : Context.ConnectionId;
            //判断连接池里是否有该用户
            if (_connections.GetConnections(username).Any())
            {
                //如果
                if (!_connections.GetConnections(username).Contains(connectionId))
                {
                    _connections.Add(username, id);
                }
                Clients.Caller.OnReconnected(username, id);
            }
            else
            {
                _connections.Add(username, id);
                Clients.Caller.onConnected(username, id);
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
        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    var item = _connections..FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    if (item != null)
        //    {
        //        ConnectedUsers.Remove(item);

        //        var id = Context.ConnectionId;
        //        Clients.All.onUserDisconnected(id, item.UserName);
        //    }
        //    return base.OnDisconnected(stopCalled);
        //}

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="fromUserName"></param>
        /// <param name="toUserName"></param>
        /// <param name="message"></param>
        public void Send(string fromUserName, string toUserName, string message)
        {
            var toUser = _connections.GetConnections(toUserName);

            if (toUser != null && fromUserName.Length > 0)
            {
                foreach (var connectionId in _connections.GetConnections(toUserName))
                {
                    Clients.Client(connectionId).send(fromUserName, toUserName, message);
                }
                Clients.Caller.send(fromUserName, toUserName, message); ;
            }
            Console.WriteLine(fromUserName + "对" + toUserName + "说:" + message);
        }
    }
}
