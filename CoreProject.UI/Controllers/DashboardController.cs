using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
