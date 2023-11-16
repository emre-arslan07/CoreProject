using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
