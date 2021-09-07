using ELAKIL.Business.IService;
using ELAKIL.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Controllers
{
    public class ContactUsController:Controller
    {
        private readonly IMailService _mailService;

        public ContactUsController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(MessageModel messageModel)
        {
            try
            {
               await _mailService.SendAsync(messageModel);
               TempData["Mess_Succ"] = "Message is send successfull we will contact with you";
            }
            catch (Exception)
            {

                TempData["Mess_Fail"] = "Sorry,sir please write valid data";
            }
            return View(messageModel);
        }
    }
}
