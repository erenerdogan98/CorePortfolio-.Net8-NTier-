using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.LayoutViewComponents
{
    public class LayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
