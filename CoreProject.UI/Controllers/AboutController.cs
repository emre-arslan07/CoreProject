using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.Entity.Concrete;
using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<AboutVM> _validator;

        public AboutController(INotyfService notyfService, IValidator<AboutVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {         
            return View(await GenericApiProvider<AboutVM>.GetTentityAsync("About","GetAbout"));
        }


        [HttpPost]
        public async Task<IActionResult> Index(AboutVM aboutVM)
        {
            ValidationResult result = await _validator.ValidateAsync(aboutVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("Index", aboutVM);
            }
            else
            {              
                if (await GenericApiProvider<AboutVM>.EditTentityAsync("About",aboutVM))
                {
                    _notyfService.Success("Düzenleme işlemi başarılı");                    
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyfService.Success("Düzenleme işlemi başarısız");
                    return RedirectToAction("Index");
                }
            }
        }
    }
}