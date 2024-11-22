using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Invoicing
{
    public class BonusAndDiscountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
