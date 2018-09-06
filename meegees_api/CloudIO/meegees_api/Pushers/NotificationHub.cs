using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using application.brain.Declaration;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace meegees_api.Pushers
{
    // [Authorize]
    public class NotificationHub : Hub
    {
        private readonly ICommon _common;

        public NotificationHub(ICommon common)
        {
            _common = common;
        }

        [HubMethodName("notifyuser")]
        public void NotifyUser(string payload, string userId)
        {
            Clients.Clients(_common.GetConnectedUsers(userId)).notifyClients(payload);
        }

        public void GetRealTime()
        {
            Clients.All.setRealTime(DateTime.Now.ToString("h:mm:ss tt"));
        }

        [HubMethodName("sendFriendRequestNotification")]
        public void FriendRequestNotification(int requestId)
        {
            var user = _common.GetConnectionIdForFriendRequest(requestId);
            if (user != null)
            {
                var ids = new List<string>();
                ids.Add(user.ConnectionId);
                Clients.Clients(ids).notifyFriendRequest(user.UserName + " wants to connect with you");
            }
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    return base.OnDisconnected(stopCalled);
        //}

        //public override Task OnReconnected()
        //{
        //    return base.OnReconnected();
        //}
    }
}