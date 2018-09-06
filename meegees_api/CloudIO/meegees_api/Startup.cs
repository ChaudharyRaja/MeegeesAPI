using System;
using System.Collections.Generic;
using System.Linq;
using application.brain.Defination;
using meegees_api.Pushers;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using  Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(meegees_api.Startup))]

namespace meegees_api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            GlobalHost.DependencyResolver.Register(typeof(NotificationHub),()=>new NotificationHub(new Common()));
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
