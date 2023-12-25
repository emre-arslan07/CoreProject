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
            return View(await GenericApiProvider<TestimonialVM>.GetListAsync("Testimonial", "GetAllTestimonial"));
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
                if (await GenericApiProvider<TestimonialVM>.AddTentityAsync("Testimonial","AddTestimonial",testimonialVM)==true)
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
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Testimonial",id)==true)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditTestimonial(int id)
        {
            return View(await GenericApiProvider<TestimonialVM>.GetByIdTentityAsync("Testimonial", null, id));
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
                if (await GenericApiProvider<TestimonialVM>.EditTentityAsync("Testimonial",testimonialVM)==true)
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