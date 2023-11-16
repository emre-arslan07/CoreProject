﻿using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7111/api/Default/GetExperience");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ExperienceVM>>(jsonString);
            return View(values);
        }
    }
}
