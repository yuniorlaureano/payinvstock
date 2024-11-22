using Microsoft.AspNetCore.Mvc;

namespace Payinvstock.Api.Controllers.General
{
    public class BlobsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
