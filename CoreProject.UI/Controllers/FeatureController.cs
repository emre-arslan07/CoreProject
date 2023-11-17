using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    public class FeatureController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Feature/GetFeature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<FeatureVM>(jsonString);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(FeatureVM featureVM)
        {
            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(featureVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Feature",
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
