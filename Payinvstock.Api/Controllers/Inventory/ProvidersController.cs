﻿using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Inventory
{
    public class ProvidersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
