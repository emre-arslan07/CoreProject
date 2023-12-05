using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class AdminMap:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
