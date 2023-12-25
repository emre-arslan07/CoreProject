using CoreProject.UI.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class FeatureStatistics2:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {           
            ViewBag.MessageCount = await GenericApiProvider<int>.GetTentityAsync("Message", "GetMessageCount");
            ViewBag.PortfolioCount = await GenericApiProvider<int>.GetTentityAsync("Portfolio", "GetPortfolioCount"); 
            ViewBag.ServiceCount = await GenericApiProvider<int>.GetTentityAsync("Service", "GetServiceCount"); 

            return View();
        }
    }
}
