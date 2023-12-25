using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View(await GenericApiProvider<PortfolioVM>.GetListAsync("Default", "GetPortfolio"));
        }
    }
}
