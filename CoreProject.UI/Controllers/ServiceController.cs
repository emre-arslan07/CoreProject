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
    public class ServiceController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<ServiceVM> _validator;

        public ServiceController(INotyfService notyfService, IValidator<ServiceVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Service/GetService");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ServiceVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceVM serviceVM)
        {
            ValidationResult result = await _validator.ValidateAsync(serviceVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddService", serviceVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(serviceVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/Service/AddService",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Ekleme işlemi başarılı", 3);
                    return RedirectToAction("AddService", "Service");
                }
                else
                {
                    _notyfService.Error("Ekleme işlemi başarısız", 3);
                    return RedirectToAction("AddService", "Service");
                }
            }
        }
        public async Task<IActionResult> DeleteService(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditService(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ServiceVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditService(ServiceVM serviceVM )
        {
            ValidationResult result = await _validator.ValidateAsync(serviceVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("EditService", serviceVM);
            }
            else
            {

                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(serviceVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Service",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    _notyfService.Success("Düzenleme işlemi başarılı", 3);
                    return RedirectToAction("EditService", "Service");
                }
                else
                {
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    _notyfService.Error("Düzenleme işlemi başarısız", 3);
                    return RedirectToAction("EditService", "Service");

                }


            }
            }
    }
}
