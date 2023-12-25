using CoreProject.Entity.Concrete;
using CoreProject.UI.ApiProvider;
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
            return View(await GenericApiProvider<WriterMessageVM>.GetMessagesByEmailTentityAsync("WriterMessage", "GetMessageInbox", mail));
        }
        [HttpGet]
        [Route("")]
        [Route("Sendbox")]
        public async Task<IActionResult> Sendbox()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;          
            return View(await GenericApiProvider<WriterMessageVM>.GetMessagesByEmailTentityAsync("WriterMessage", "GetMessageSendbox", mail));
        }
      
        [HttpGet]
        [Route("InboxMessageDetails/{id}")]
        public async Task<IActionResult> InboxMessageDetails(int id)
        {          
            return View(await GenericApiProvider<WriterMessageVM>.GetByIdTentityAsync("WriterMessage", "GetWriterMessageById",id));
        }
        [HttpGet]
        [Route("SendboxMessageDetails/{id}")]
        public async Task<IActionResult> SendboxMessageDetails(int id)
        {                       
            return View(await GenericApiProvider<WriterMessageVM>.GetByIdTentityAsync("WriterMessage", "GetWriterMessageById", id));
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
        public async Task<IActionResult> SendMessage(WriterMessageVM writerMessage)
        {
            var valuesSender = await _userManager.FindByNameAsync(User.Identity.Name);          
            writerMessage.Sender = valuesSender.Email;
            writerMessage.SenderName = valuesSender.Name +" "+valuesSender.Surname;
            writerMessage.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.Sender=valuesSender.Email;
            writerMessage.SenderName=valuesSender.Name +" "+valuesSender.Surname;
            var receiverValue = _userManager.FindByEmailAsync(writerMessage.Receiver);
            writerMessage.ReceiverName = receiverValue.Result.Name + " " + receiverValue.Result.Surname;           
            if (await GenericApiProvider<WriterMessageVM>.AddTentityAsync("WriterMessage", "SendWriterMessage", writerMessage) ==true)
            {               
                return RedirectToAction("Sendbox","Message");
            }
            return View();

        }
    }
}
