﻿using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Skill
{
    public class SkillList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {           
            return View(await GenericApiProvider<SkillVM>.GetListAsync("Default", "GetSkill"));
        }
    }
}
