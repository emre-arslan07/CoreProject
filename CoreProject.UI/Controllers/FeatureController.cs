using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.Entity.Concrete;
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

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Feature/GetFeature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<FeatureVM>(jsonString);
                return View(values);
            }
            return View();
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
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(featureVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Feature",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Düzenleme işlemi başarılı", 3);
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyfService.Error("Düzenleme işlemi başarısız", 3);
                    return RedirectToAction("EditExperience", "Experience");

                }
            }

        }
    }
}