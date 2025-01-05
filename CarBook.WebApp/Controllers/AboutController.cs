using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
