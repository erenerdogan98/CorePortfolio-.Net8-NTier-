using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class AboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
