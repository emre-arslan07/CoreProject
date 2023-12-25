using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.Entity.Concrete;
using CoreProject.UI.ApiProvider;
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
            return View(await GenericApiProvider<SkillVM>.GetListAsync("Skill","GetSkill"));
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
                if (await GenericApiProvider<SkillVM>.AddTentityAsync("Skill","AddSkill",skillVM)==true)
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
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Skill",id)==true)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSkill(int id)
        {                    
            return View(await GenericApiProvider<SkillVM>.GetByIdTentityAsync("Skill",null,id));
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
                if (await GenericApiProvider<SkillVM>.EditTentityAsync("Skill",skillVM)==true)
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
