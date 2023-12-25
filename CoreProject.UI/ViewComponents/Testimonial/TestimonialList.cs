using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {          
            return View(await GenericApiProvider<TestimonialVM>.GetListAsync("Default", "GetTestimonial"));

        }
    }
}
