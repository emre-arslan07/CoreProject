using CoreProject.Entity.Concrete;
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
            @ViewBag.InboxCount = 0;

            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7111/api/Announcement/GetAnnouncementCount");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<int>(jsonString2);
            ViewBag.AnnouncementCount = values2;

            var responseMessage3 = await httpClient.GetAsync("https://localhost:7111/api/AppUser/GetUserCount");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<int>(jsonString3);
            ViewBag.UserCount = values3;

            var responseMessage4 = await httpClient.GetAsync("https://localhost:7111/api/Skill/GetSkillCount");
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();
            var values4 = JsonConvert.DeserializeObject<int>(jsonString4);
            ViewBag.SkillCount = values4;
            return View();
        }
    }
}
