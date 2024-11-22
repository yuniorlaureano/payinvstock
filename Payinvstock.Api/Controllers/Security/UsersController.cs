using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.Security
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
