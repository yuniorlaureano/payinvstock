using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Settings
{
    public class BlobSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
