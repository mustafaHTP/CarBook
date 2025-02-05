using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class BrandStatisticsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
