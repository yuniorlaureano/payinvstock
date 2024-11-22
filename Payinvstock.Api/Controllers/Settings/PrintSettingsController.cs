using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Settings
{
    public class PrintSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
