using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreProject.UI.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Portfolio/GetPortfolio");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PortfolioVM>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioVM portfolioVM)
        { 
            portfolioVM.Value = 100;
            portfolioVM.Status = true;
            portfolioVM.Image1 = "asd";
            portfolioVM.Image2 = "sdasd";
            portfolioVM.Image3 = "sdasd";
            portfolioVM.Image4 = "sdasd";
            portfolioVM.Platform = "asdasd";
            portfolioVM.Price = "500";

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(portfolioVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7111/api/Portfolio/AddPortfolio",
             content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync($"https://localhost:7111/api/Portfolio/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Thread.Sleep(1000);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditPortfolio(int id)
        {

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"https://localhost:7111/api/Portfolio/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<PortfolioVM>(jsonString);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(PortfolioVM portfolioVM)
        {

            var httpClient = new HttpClient();
            var jsonBlog = JsonConvert.SerializeObject(portfolioVM);
            StringContent content = new StringContent(jsonBlog, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7111/api/Portfolio",
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
