using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error404() 
        {
            return View();
        }
    }
}
