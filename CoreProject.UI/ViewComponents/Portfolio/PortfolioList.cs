using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Default/GetPortfolio");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PortfolioVM>>(jsonString);
            return View(values);
        }
    }
}
