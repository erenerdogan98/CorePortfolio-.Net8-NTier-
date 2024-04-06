using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class ContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
