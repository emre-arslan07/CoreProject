using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace CoreProject.UI.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View(await GenericApiProvider<FeatureVM>.GetListAsync("Default", "GetFeature"));
        }
    }
}
