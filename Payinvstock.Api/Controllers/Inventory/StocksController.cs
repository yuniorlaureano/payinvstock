using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Inventory
{
    public class StocksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
