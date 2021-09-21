using ELAKIL.Business.IService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IMessageService messageService;

        public ChatHub(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        public async Task SendMessage(string user, string message)
        {
            await this.messageService.AddAsync(user,Context.User.Identity.Name,message);
            await Clients.Group(user).SendAsync("ReceiveMessage",user,message);
        }
        public async override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
               await  Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            }
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string name = Context.User.Identity.Name;
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, name);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
