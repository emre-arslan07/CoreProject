using AspNetCoreHero.ToastNotification.Abstractions;
using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {

        public async Task<IActionResult> Index()
        {            
            return View(await GenericApiProvider<MessageVM>.GetListAsync("Message", "GetAllMessage"));
        }

        public async Task<IActionResult> DeleteContact(int id)
        {          
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Message",id)==true)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        public async Task<IActionResult> ContactDetails(int id)
        {
            return View(await GenericApiProvider<MessageVM>.GetByIdTentityAsync("Message", null, id));
        }
    }
}
