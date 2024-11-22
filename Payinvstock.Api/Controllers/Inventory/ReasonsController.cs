using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Inventory
{
    public class ReasonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
