using CoreProject.UI.ApiProvider;
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
            return View(await GenericApiProvider<AnnouncementVM>.GetListAsync("Announcement", "GetLast5Announcement"));
        }
    }
}
