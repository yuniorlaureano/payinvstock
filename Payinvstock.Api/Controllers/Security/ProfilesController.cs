using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Security
{
    public class ProfilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
