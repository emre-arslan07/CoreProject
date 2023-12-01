using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Controllers
{
    public class AdminMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
