using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class FeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
