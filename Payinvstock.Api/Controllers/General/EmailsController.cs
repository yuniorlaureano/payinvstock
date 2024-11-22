using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.General
{
    public class EmailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
