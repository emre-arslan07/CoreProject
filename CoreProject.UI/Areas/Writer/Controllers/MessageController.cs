using CoreProject.Entity.Concrete;
using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/WriterMessage/GetMessageInbox/{mail}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WriterMessageVM>>(jsonString);
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
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/WriterMessage/GetMessageSendbox/{mail}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WriterMessageVM>>(jsonString);
                return View(values);
            }
            return View();
        }
    }
}
