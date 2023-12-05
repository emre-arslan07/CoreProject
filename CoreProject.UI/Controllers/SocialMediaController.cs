using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    public class SocialMediaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/SocialMedia/GetAllSocialMedia");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SocialMediaVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMediaVM socialMediaVM)
        {

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(socialMediaVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/SocialMedia/AddSocialMedia",
             content);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteSocialMedia(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSocialMedia(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SocialMediaVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditSocialMedia(SocialMediaVM socialMediaVM)
        {

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(socialMediaVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/SocialMedia",
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
