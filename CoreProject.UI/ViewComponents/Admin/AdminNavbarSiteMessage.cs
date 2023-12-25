using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Admin
{
    public class AdminNavbarSiteMessage:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {           
            return View(await GenericApiProvider<SiteMessageVM>.GetListAsync("Message", "GetLast3Message"));
        }
    }
}
