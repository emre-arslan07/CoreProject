using CoreProject.Entity.Concrete;
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

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]       
        public async Task<IActionResult> Inbox()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/AdminMessage/GetAdminMessageInbox/{mail}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminMessageVM>>(jsonString);
                return View(values);
            }
            return View();
        }
        [HttpGet]       
        public async Task<IActionResult> Sendbox()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/AdminMessage/GetAdminMessageSendbox/{mail}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminMessageVM>>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InboxMessageDetails(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/AdminMessage/GetAdminMessageById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AdminMessageVM>(jsonString);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SendboxMessageDetails(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/AdminMessage/GetAdminMessageById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AdminMessageVM>(jsonString);
                return View(values);
            }
            return View();
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
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(adminMessage);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/AdminMessage/SendAdminMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<SkillVM>(jsonString);
                return RedirectToAction("Sendbox", "AdminMessage");
            }
            return View();

        }
        public async Task<IActionResult> AdminMessageDelete(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/AdminMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
