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

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/About/GetAbout");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AboutVM>(jsonString);
                return View(values);
            }
            return View();
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
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(aboutVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/About",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Düzenleme işlemi başarılı");
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyfService.Success("Düzenleme işlemi başarısız");
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}