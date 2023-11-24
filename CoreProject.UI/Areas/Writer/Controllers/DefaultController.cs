﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
