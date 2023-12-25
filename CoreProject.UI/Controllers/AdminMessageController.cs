using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.Entity.Concrete;
using CoreProject.UI.ApiProvider;
using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotyfService _notyfService;


        public AdminMessageController(UserManager<AppUser> userManager, INotyfService notyfService)
        {
            _userManager = userManager;
            _notyfService = notyfService;
        }
        [HttpGet]       
        public async Task<IActionResult> Inbox()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;      
            return View(await GenericApiProvider<AdminMessageVM>.GetMessagesByEmailTentityAsync("AdminMessage", "GetAdminMessageInbox",mail));
        }
        [HttpGet]       
        public async Task<IActionResult> Sendbox()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;          
            return View(await GenericApiProvider<AdminMessageVM>.GetMessagesByEmailTentityAsync("AdminMessage", "GetAdminMessageSendbox", mail));
        }

        [HttpGet]
        public async Task<IActionResult> InboxMessageDetails(int id)
        {
            return View(await GenericApiProvider<AdminMessageVM>.GetByIdTentityAsync("AdminMessage", "GetAdminMessageById",id));
        }
        [HttpGet]
        public async Task<IActionResult> SendboxMessageDetails(int id)
        {           
            return View(await GenericApiProvider<AdminMessageVM>.GetByIdTentityAsync("AdminMessage", "GetAdminMessageById", id));
        }

        [HttpGet]       
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]      
        public async Task<IActionResult> SendMessage(AdminMessageVM adminMessage)
        {
            var valuesSender = await _userManager.FindByNameAsync(User.Identity.Name);
            adminMessage.Sender = valuesSender.Email;
            adminMessage.SenderName = valuesSender.Name + " " + valuesSender.Surname;
            adminMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            adminMessage.Sender = valuesSender.Email;
            adminMessage.SenderName = valuesSender.Name + " " + valuesSender.Surname;
            var receiverValue = _userManager.FindByEmailAsync(adminMessage.Receiver);
            adminMessage.ReceiverName = receiverValue.Result.Name + " " + receiverValue.Result.Surname;
           
            if (await GenericApiProvider<AdminMessageVM>.AddTentityAsync("AdminMessage", "SendAdminMessage", adminMessage)==true)
            {
                _notyfService.Success("Mesajınız başarıyla gönderildi");               
                return RedirectToAction("Sendbox", "AdminMessage");
            }
            else
            {
                _notyfService.Error("Mesajınız gönderilemedi");              
                return RedirectToAction("Sendbox", "AdminMessage");
            }
            return View();

        }
        public async Task<IActionResult> AdminMessageDelete(int id)
        {          
            if (await GenericApiProvider<bool>.DeleteTentityAsync("AdminMessage", id)==true)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
