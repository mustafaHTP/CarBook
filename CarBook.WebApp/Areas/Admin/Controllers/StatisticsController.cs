using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
