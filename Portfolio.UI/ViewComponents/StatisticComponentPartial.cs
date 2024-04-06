using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class StatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
