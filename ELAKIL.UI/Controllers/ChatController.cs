using ELAKIL.Business.IService;
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

        public ChatController(IMessageService messageService,IUserProfileService userProfileService)
        {
            this.messageService = messageService;
            this.userProfileService = userProfileService;
        }
        public IActionResult Index()
        {
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
