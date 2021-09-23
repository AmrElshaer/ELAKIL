using ELAKIL.Business.IService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IMessageService messageService;
        private readonly ChatService chatService;

        public ChatHub(IMessageService messageService,ChatService chatService)
        {
            this.messageService = messageService;
            this.chatService = chatService;
        }
        public async Task SendMessage(string user, string message)
        {
            await this.messageService.AddAsync(user,Context.User.Identity.Name,message);
            await Clients.Group(user).SendAsync("ReceiveMessage",user,message);
            if (!chatService.ActiveUsers.ContainsKey(user))
            {
               
                if( this.chatService.MessagesNotSee.TryGetValue(user, out int count))
                {
                    this.chatService.MessagesNotSee.TryUpdate(user, count + 1, count);
                }
                else
                {
                    this.chatService.MessagesNotSee.TryAdd(user, 1);
                }
            }
        }
        public async override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {

                await  Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
                chatService.ActiveUsers.TryAdd(Context.User.Identity.Name,true);
            }
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
               
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
                chatService.ActiveUsers.TryRemove(Context.User.Identity.Name,out bool active);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
