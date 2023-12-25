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
    public class FeatureController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<FeatureVM> _validator;

        public FeatureController(INotyfService notyfService, IValidator<FeatureVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<FeatureVM>.GetTentityAsync("Feature","GetFeature"));
        }


        [HttpPost]
        public async Task<IActionResult> Index(FeatureVM featureVM)
        {
            ValidationResult result = await _validator.ValidateAsync(featureVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("Index", featureVM);
            }
            else
            {              
                if (await GenericApiProvider<FeatureVM>.EditTentityAsync("Feature", featureVM)==true)
                {
                    _notyfService.Success("Düzenleme işlemi başarılı", 3);
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyfService.Error("Düzenleme işlemi başarısız", 3);
                    return RedirectToAction("Index");

                }
            }
        }
    }
}