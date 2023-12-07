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

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Contact/GetContactById");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ContactVM>(jsonString);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(ContactVM contactVM)
        {
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(contactVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Contact",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
