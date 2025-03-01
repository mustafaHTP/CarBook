using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Controllers
{
    public class AuthController : Controller
    {
        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}
