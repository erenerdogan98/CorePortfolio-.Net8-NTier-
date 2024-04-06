using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
