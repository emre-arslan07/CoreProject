using CoreProject.UI.ApiProvider;
using CoreProject.UI.Areas.Writer.Models;
using CoreProject.UI.Models;
using CoreProject.UI.ValidationRules;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IValidator<UserRegisterVM> _validator;

        public RegisterController(IValidator<UserRegisterVM> validator)
        {
            _validator = validator;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {  
            ValidationResult result=await _validator.ValidateAsync(userRegisterVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }              
                return View("Index",userRegisterVM);
            }
            else
            {
                AppUserRegisterVM newUser=new AppUserRegisterVM{ 
                    Name=userRegisterVM.Name,
                    Surname=userRegisterVM.Surname,
                    UserName=userRegisterVM.UserName,
                    Password=userRegisterVM.Password,
                    Mail=userRegisterVM.Mail
                };
                if (await GenericApiProvider<AppUserRegisterVM>.AddTentityAsync("AppUser","AppUserRegister", newUser) == true)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }
    }
}
