using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.SocialMedia
{
    public class SocialMediaTopLinks:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View(await GenericApiProvider<SocialMediaVM>.GetListAsync("SocialMedia", "GetAllSocialMedia"));

        }
    }
}
