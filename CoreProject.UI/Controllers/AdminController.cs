﻿using Microsoft.AspNetCore.Mvc;

namespace CoreProject.UI.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar() 
        {
        return PartialView();
        }
        public PartialViewResult PartialHeader() 
        {
            return PartialView();
        }
        public PartialViewResult PartialScript() 
        {
            return PartialView();
        }
    }
}
