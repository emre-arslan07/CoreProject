using CoreProject.UI.ApiProvider;
using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        [Route("Writer/Default/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<AnnouncementVM>.GetListAsync("Announcement", "GetAnnouncement"));
        }


        [HttpGet]
        public async Task<IActionResult> AnnouncementDetail(int id)
        {
          
            return View(await GenericApiProvider<AnnouncementVM>.GetByIdTentityAsync("Announcement", null,id));
        }


    }
}
