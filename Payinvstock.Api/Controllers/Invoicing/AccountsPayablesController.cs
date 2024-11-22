using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Invoicing
{
    public class AccountsPayablesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
