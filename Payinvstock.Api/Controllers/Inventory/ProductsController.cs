﻿using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Inventory
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}