using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {           
            return View(await GenericApiProvider<ServiceVM>.GetListAsync("Default", "GetService"));
        }
    }
}
