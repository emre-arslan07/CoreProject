using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.UI.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<ExperienceVM> _validator;

        public ExperienceController(INotyfService notyfService,IValidator<ExperienceVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Experience/GetExperience");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ExperienceVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(ExperienceVM experienceVM )
        {
            ValidationResult result = await _validator.ValidateAsync(experienceVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddExperience",experienceVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(experienceVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/Experience/AddExperience",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Ekleme işlemi başarılı", 3);
                    return RedirectToAction("AddExperience", "Experience");
                }
                else
                {
                    _notyfService.Error("Ekleme işlemi başarısız", 3);
                    return RedirectToAction("AddExperience", "Experience");
                }
            }           
        }

        public async Task<IActionResult> DeleteExperience(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/Experience/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {               
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditExperience(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/Experience/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExperienceVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(ExperienceVM experienceVM)
        {
           

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(experienceVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Experience",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("AddExperience", "Experience");
            }
            else
            {
                _notyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("AddExperience", "Experience");

            }



        }
    }
}
