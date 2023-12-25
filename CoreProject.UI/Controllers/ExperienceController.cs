using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.UI.ApiProvider;
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
            return View(await GetListProvider<ExperienceVM>.GetListAsync("Experience","GetExperience"));
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
                if (await GenericApiProvider<ExperienceVM>.AddTentityAsync("Experience","AddExperience",experienceVM)==true)
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
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Experience",id)==true)
            {               
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditExperience(int id)
        {
           return View(await GenericApiProvider<ExperienceVM>.GetByIdTentityAsync("Experience",null,id));          
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(ExperienceVM experienceVM)
        {
            ValidationResult result = await _validator.ValidateAsync(experienceVM);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("EditExperience", experienceVM);
            }
            else
            {               
                if (await GenericApiProvider<ExperienceVM>.EditTentityAsync("Experience",experienceVM)==true)
                {
                    _notyfService.Success("Düzenleme işlemi başarılı", 3);
                    return RedirectToAction("EditExperience", "Experience");
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
