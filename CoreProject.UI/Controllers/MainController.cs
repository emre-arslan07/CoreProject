using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
