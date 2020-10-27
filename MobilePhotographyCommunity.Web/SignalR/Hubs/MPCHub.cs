using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhotographyCommunity.Web.SignalR.Hubs
{
    public class MPCHub : Hub
    {
        public void Send(string name, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MPCHub>();
            context.Clients.All.displayStatus();
        }
    }
}