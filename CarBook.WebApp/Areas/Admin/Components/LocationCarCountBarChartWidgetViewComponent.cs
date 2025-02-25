using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class LocationCarCountBarChartWidgetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
