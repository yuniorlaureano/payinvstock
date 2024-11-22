using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Settings
{
    public class EmailSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
