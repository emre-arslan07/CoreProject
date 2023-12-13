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
    public class SocialMediaController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<SocialMediaVM> _validator;

        public SocialMediaController(INotyfService notyfService, IValidator<SocialMediaVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/SocialMedia/GetAllSocialMedia");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SocialMediaVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMediaVM socialMediaVM)
        {
            ValidationResult result = await _validator.ValidateAsync(socialMediaVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddSocialMedia", socialMediaVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(socialMediaVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/SocialMedia/AddSocialMedia",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Ekleme işlemi başarılı", 3);
                    return RedirectToAction("AddSocialMedia", "SocialMedia");
                }
                else
                {
                    _notyfService.Error("Ekleme işlemi başarısız", 3);
                    return RedirectToAction("AddSocialMedia", "SocialMedia");
                }
            }
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSocialMedia(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SocialMediaVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditSocialMedia(SocialMediaVM socialMediaVM)
        {
            ValidationResult result = await _validator.ValidateAsync(socialMediaVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("EditSocialMedia", socialMediaVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(socialMediaVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/SocialMedia",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Güncelleme işlemi başarılı", 3);
                    return RedirectToAction("EditSocialMedia", "SocialMedia");
                }
                else
                {
                    _notyfService.Error("Güncelleme işlemi başarısız", 3);
                    return RedirectToAction("EditSocialMedia", "SocialMedia");
                }

            }

        }
    }
}
