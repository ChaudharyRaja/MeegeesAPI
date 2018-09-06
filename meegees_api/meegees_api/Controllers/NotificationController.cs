using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using meegees_api.Pushers;
using Microsoft.AspNet.SignalR;

namespace meegees_api.Controllers
{
    public class NotificationController : ApiController
    {
        // private readonly IHubContext<NotificationHub> _hubContext;
        private readonly INotificationHubClient _hubContext;

        public NotificationController(INotificationHubClient hubContext)
        {
            _hubContext = hubContext;
        }

    }
}
