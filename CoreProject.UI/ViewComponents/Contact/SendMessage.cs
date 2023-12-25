using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {            
            return View(await GenericApiProvider<MessageVM>.GetListAsync("Default", "SendMessage"));
        }
    }
}
