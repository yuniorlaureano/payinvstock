using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.General
{
    public class DashboardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
