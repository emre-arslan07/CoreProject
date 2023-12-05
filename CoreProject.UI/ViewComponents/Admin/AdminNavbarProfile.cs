using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.ViewComponents.Admin
{
    public class AdminNavbarProfile:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
