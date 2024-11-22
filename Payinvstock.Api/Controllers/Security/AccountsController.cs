using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Security
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
