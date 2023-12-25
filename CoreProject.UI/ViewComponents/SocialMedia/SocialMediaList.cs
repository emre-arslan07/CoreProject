using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {           
            return View(await GenericApiProvider<SocialMediaVM>.GetListAsync("Default", "GetSocialMedia"));
        }
    }
}
