using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() {  return View(); }
    }
}
