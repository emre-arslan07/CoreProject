using CoreProject.Entity.Concrete;
using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Route("")]
        [Route("Inbox")]
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
        [Route("")]
        [Route("Sendbox")]
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
      
        [HttpGet]
        [Route("InboxMessageDetails/{id}")]
        public async Task<IActionResult> InboxMessageDetails(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/WriterMessage/GetWriterMessageById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WriterMessageVM>(jsonString);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("SendboxMessageDetails/{id}")]
        public async Task<IActionResult> SendboxMessageDetails(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/WriterMessage/GetWriterMessageById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WriterMessageVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {
            var valuesSender = await _userManager.FindByNameAsync(User.Identity.Name);          
            writerMessage.Sender = valuesSender.Email;
            writerMessage.SenderName = valuesSender.Name +" "+valuesSender.Surname;
            writerMessage.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.Sender=valuesSender.Email;
            writerMessage.SenderName=valuesSender.Name +" "+valuesSender.Surname;
            var receiverValue = _userManager.FindByEmailAsync(writerMessage.Receiver);
            writerMessage.ReceiverName = receiverValue.Result.Name + " " + receiverValue.Result.Surname;
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(writerMessage);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/WriterMessage/SendWriterMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<SkillVM>(jsonString);
                return RedirectToAction("Sendbox","Message");
            }
            return View();

        }
    }
}
