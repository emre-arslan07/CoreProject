using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {          
            return View(await GenericApiProvider<ExperienceVM>.GetListAsync("Default", "GetExperience"));
        }
    }
}
