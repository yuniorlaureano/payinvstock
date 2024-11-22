using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Invoicing
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
