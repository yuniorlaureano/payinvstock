using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Inventory
{
    public class StockCycles : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
