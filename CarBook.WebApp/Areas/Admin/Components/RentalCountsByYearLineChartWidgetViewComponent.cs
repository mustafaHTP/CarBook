using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class RentalCountsByYearLineChartWidgetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
