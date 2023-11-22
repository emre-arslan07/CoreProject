using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class FeatureStatistics2:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage1 = await httpClient.GetAsync("https://localhost:7111/api/Message/GetMessageCount");
            var jsonString1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<int>(jsonString1);
            ViewBag.MessageCount = values1;

            var responseMessage2 = await httpClient.GetAsync("https://localhost:7111/api/Portfolio/GetPortfolioCount");
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<int>(jsonString2);
            ViewBag.PortfolioCount = values2;

            var responseMessage3 = await httpClient.GetAsync("https://localhost:7111/api/Service/GetServiceCount");
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<int>(jsonString3);
            ViewBag.ServiceCount = values3;

            return View();
        }
    }
}
