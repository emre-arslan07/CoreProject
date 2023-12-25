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
            return View(await GenericApiProvider<SocialMediaVM>.GetListAsync("SocialMedia", "GetAllSocialMedia"));
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
                if (await GenericApiProvider<SocialMediaVM>.AddTentityAsync("SocialMedia", "AddSocialMedia",socialMediaVM)==true)
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
            if (await GenericApiProvider<bool>.DeleteTentityAsync("SocialMedia",id)==true)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSocialMedia(int id)
        {
            return View(await GenericApiProvider<SocialMediaVM>.GetByIdTentityAsync("SocialMedia",null,id));
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
                if (await GenericApiProvider<SocialMediaVM>.EditTentityAsync("SocialMedia",socialMediaVM)==true)
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
