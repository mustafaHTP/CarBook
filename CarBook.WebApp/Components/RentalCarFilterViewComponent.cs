using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class RentalCarFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
