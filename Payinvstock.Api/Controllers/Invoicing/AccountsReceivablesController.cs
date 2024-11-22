using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Invoicing
{
    public class AccountsReceivablesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
