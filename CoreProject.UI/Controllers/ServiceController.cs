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
            return View(await GenericApiProvider<ServiceVM>.GetListAsync("Service","GetService"));
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
                if (await GenericApiProvider<ServiceVM>.AddTentityAsync("Service","AddService",serviceVM)==true)
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
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Service",id)==true)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditService(int id)
        {         
            return View(await GenericApiProvider<ExperienceVM>.GetByIdTentityAsync("Service",null,id));
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
                if (await GenericApiProvider<ServiceVM>.EditTentityAsync("Service",serviceVM)==true)
                {
                    _notyfService.Success("Düzenleme işlemi başarılı", 3);
                    return RedirectToAction("EditService", "Service");
                }
                else
                {
                    _notyfService.Error("Düzenleme işlemi başarısız", 3);
                    return RedirectToAction("EditService", "Service");
                }


            }
            }
    }
}
