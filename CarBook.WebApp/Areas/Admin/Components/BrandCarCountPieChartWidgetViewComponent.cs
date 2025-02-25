using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class BrandCarCountPieChartWidgetViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
