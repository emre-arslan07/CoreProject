using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubPlaceController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ContactVM>.GetByIdTentityAsync("Contact", "GetContactById",null));
        }


        [HttpPost]
        public async Task<IActionResult> Index(ContactVM contactVM)
        {          
            if (await GenericApiProvider<ContactVM>.EditTentityAsync("Contact",contactVM)==true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
