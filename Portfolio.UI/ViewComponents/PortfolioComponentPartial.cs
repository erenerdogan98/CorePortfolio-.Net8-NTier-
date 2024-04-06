using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class PortfolioComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
