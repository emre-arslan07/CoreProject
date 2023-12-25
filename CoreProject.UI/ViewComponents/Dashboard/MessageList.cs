using CoreProject.Entity.Concrete;
using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public MessageList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var valuesUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = valuesUser.Email;          
            return View(await GenericApiProvider<AdminLast3MessageNavbar>.GetMessagesByEmailTentityAsync("AdminMessage", "GetLast3MessageInbox",mail));
        }
    }
}
