using CoreProject.Entity.Concrete;
using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]

    public class LoginController : Controller
    {
        private SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginVM.Username,userLoginVM.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default",new {area="Writer"});
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
            //if (ModelState.IsValid)
            //{
            //    var httpClient = new HttpClient();
            //    var jsonBlog = JsonConvert.SerializeObject(userLoginVM);
            //    StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            //    var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/AppUser/AppUserLogin",
            //     content);
            //    if (responseMessage.IsSuccessStatusCode)
            //    {

            //        var jsonString = await responseMessage.Content.ReadAsStringAsync();
            //        var values = JsonConvert.DeserializeObject<AppUserVM>(jsonString);
            //        return RedirectToAction("Index", "Default", new {area="Writer"});

            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
            //    }
            //}
            //return View();

        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
