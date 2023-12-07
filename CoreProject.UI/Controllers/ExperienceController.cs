using CoreProject.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Experience/GetExperience");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ExperienceVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(ExperienceVM experienceVM )
        {

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(experienceVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/Experience/AddExperience",
             content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteExperience(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/Experience/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditExperience(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/Experience/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExperienceVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(ExperienceVM experienceVM)
        {

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(experienceVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Experience",
             content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<SkillVM>(jsonString);
                return RedirectToAction("Index");
            }
            return View();



        }
    }
}
