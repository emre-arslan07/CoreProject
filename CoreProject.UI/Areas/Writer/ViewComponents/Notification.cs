using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.Areas.Writer.ViewComponents
{
    public class Notification:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Announcement/GetLast5Announcement");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AnnouncementVM>>(jsonString);


            return View(values);
        }
    }
}
