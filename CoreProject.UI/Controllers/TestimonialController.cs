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
    public class TestimonialController : Controller
    {
        private readonly INotyfService _notyfService;
        private readonly IValidator<TestimonialVM> _validator;

        public TestimonialController(INotyfService notyfService, IValidator<TestimonialVM> validator)
        {
            _notyfService = notyfService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Testimonial/GetAllTestimonial");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TestimonialVM>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialVM testimonialVM)
        {
            ValidationResult result = await _validator.ValidateAsync(testimonialVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddTestimonial", testimonialVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(testimonialVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/Testimonial/AddTestimonial",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Ekleme işlemi başarılı", 3);
                    return RedirectToAction("AddTestimonial", "Testimonial");
                }
                else
                {
                    _notyfService.Error("Ekleme işlemi başarısız", 3);
                    return RedirectToAction("AddTestimonial", "Testimonial");
                }
            }
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditTestimonial(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialVM>(jsonString);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditTestimonial(TestimonialVM testimonialVM)
        {
            ValidationResult result = await _validator.ValidateAsync(testimonialVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("EditTestimonial", testimonialVM);
            }
            else
            {
                var httpClient = new HttpClient();
                var jsonBlog = JsonConvert.SerializeObject(testimonialVM);
                StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Testimonial",
                 content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _notyfService.Success("Güncelleme işlemi başarılı", 3);
                    return RedirectToAction("EditTestimonial", "Testimonial");
                }
                else
                {
                    _notyfService.Error("Güncelleme işlemi başarısız", 3);
                    return RedirectToAction("EditTestimonial", "Testimonial");
                }
            }
        }
    }
}