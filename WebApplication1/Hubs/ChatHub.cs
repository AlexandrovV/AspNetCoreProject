using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            if (user == "") user = "Anonymous";
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
