using CoreProject.UI.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Index(UserLoginVM userLoginVM)
        {
            return View();
        }
    }
}
