using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {


            var httpClient = new HttpClient();
            var responseMessage1 = await httpClient.GetAsync("https://localhost:7111/api/Message/GetTrueMessageCount");
            var jsonString1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<int>(jsonString1);
            ViewBag.TrueCount = values1;

            var responseMessage2 = await httpClient.GetAsync("https://localhost:7111/api/Message/GetFalseMessageCount");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<int>(jsonString2);
            ViewBag.FalseCount = values2;

            var responseMessage3 = await httpClient.GetAsync("https://localhost:7111/api/Experience/GetExperienceCount");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<int>(jsonString3);
            ViewBag.ExpCount = values3;

            var responseMessage4 = await httpClient.GetAsync("https://localhost:7111/api/Skill/GetSkillCount");
            var jsonString4 = await responseMessage4.Content.ReadAsStringAsync();
            var values4 = JsonConvert.DeserializeObject<int>(jsonString4);
            ViewBag.SkillCount = values4;
            return View();
        }
    }
}
