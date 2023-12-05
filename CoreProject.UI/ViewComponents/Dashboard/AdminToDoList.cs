using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class AdminToDoList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
