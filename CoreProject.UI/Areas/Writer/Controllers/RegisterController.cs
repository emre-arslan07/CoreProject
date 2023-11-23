using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using CoreProject.UI.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {  
            UserRegisterValidator validations = new UserRegisterValidator();
            ValidationResult result=validations.Validate(userRegisterVM);
            if (result.IsValid)
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(userRegisterVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/AppUser/AppUserRegister",
                 content);
                return RedirectToAction("Index","Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
