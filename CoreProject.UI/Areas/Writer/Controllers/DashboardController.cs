using CoreProject.Entity.Concrete;
using CoreProject.UI.ApiProvider;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name=values.Name+" "+ values.Surname;

            //Weather api
            string apiKey = "1f4c32f587158ec918e8fe2e0b7e43f8";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;
            XDocument xDocument= XDocument.Load(connection);
            ViewBag.Tempreture = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value.Substring(0,2);
           
            ViewBag.InboxCount = await GenericApiProvider<int>.GetMessagesCountByEmailTentityAsync("WriterMessage", "GetWriterMessageInboxCount", values.Email);      
            ViewBag.AnnouncementCount = await GenericApiProvider<int>.GetTentityAsync("Announcement", "GetAnnouncementCount");     
            ViewBag.UserCount = await GenericApiProvider<int>.GetTentityAsync("AppUser", "GetUserCount");         
            ViewBag.SkillCount = await GenericApiProvider<int>.GetTentityAsync("Skill", "GetSkillCount");
            return View();
        }
    }
}
