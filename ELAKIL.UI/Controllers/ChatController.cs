using ELAKIL.Business.IService;
using ELAKIL.UI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IUserProfileService userProfileService;
        private readonly ChatService chatService;

        public ChatController(IMessageService messageService,IUserProfileService userProfileService,ChatService chatService)
        {
            this.messageService = messageService;
            this.userProfileService = userProfileService;
            this.chatService = chatService;
        }
        public IActionResult Index()
        {
            chatService.MessagesNotSee.TryRemove(User.Identity.Name,out int count);
            return View();
        }
        public async Task<IActionResult> ChatWith(int toUser)
        {
            ViewBag.User = (await userProfileService.GetUserProfileAsync(toUser)).Name;
            var messages = await messageService.GetMessagesAsync(toUser);
            return View(messages);
        }
    }
}
