using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class TestimonialComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
