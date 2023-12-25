﻿using CoreProject.UI.ApiProvider;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreProject.UI.ViewComponents.Contact
{
    public class ContactList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {          
            return View(await GenericApiProvider<ContactVM>.GetListAsync("Default", "GetContact"));
        }
    }
}
