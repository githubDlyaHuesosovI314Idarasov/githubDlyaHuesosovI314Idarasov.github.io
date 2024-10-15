using Microsoft.AspNetCore.Mvc;

namespace WebFlightCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatabaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
