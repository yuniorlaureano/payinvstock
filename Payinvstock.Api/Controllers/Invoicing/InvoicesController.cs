using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Invoicing
{
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
