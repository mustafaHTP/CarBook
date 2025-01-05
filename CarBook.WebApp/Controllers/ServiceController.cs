using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
