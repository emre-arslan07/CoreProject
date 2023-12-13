using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.Entity.Concrete;
using CoreProject.UI.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<SkillVM> _validator;

        public SkillController(INotyfService notyfService, IValidator<SkillVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Skill/GetSkill");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SkillVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddSkill()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillVM skillVM)
        {
            ValidationResult result = await _validator.ValidateAsync(skillVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddSkill", skillVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(skillVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/Skill/AddSkill",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Ekleme işlemi başarılı", 3);
                    return RedirectToAction("AddSkill", "Skill");
                }
                else
                {
                    _notyfService.Error("Ekleme işlemi başarısız", 3);
                    return RedirectToAction("AddSkill", "Skill");
                }
            }
        }
     
        public async Task<IActionResult> DeleteSkill(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/Skill/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSkill(int id)
        {
            
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/Skill/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SkillVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditSkill(SkillVM skillVM)
        {
            ValidationResult result = await _validator.ValidateAsync(skillVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddSkill", skillVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(skillVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Skill",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Düzenleme işlemi başarılı", 3);
                    return RedirectToAction("EditSkill", "Skill");
                }
                else
                {
                    _notyfService.Error("Düzenleme işlemi başarısız", 3);
                    return RedirectToAction("EditSkill", "Skill");

                }

            }

            }
    }
}
