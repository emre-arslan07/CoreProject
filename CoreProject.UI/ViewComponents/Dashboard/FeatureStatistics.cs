using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.TrueCount =await GenericApiProvider<int>.GetTentityAsync("Message", "GetTrueMessageCount");
            ViewBag.FalseCount = await GenericApiProvider<int>.GetTentityAsync("Message", "GetFalseMessageCount");            
            ViewBag.ExpCount = await GenericApiProvider<int>.GetTentityAsync("Experience", "GetExperienceCount"); 
            ViewBag.SkillCount = await GenericApiProvider<int>.GetTentityAsync("Skill", "GetSkillCount");
            return View();
        }
    }
}
