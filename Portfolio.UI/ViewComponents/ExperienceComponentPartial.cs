using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class ExperienceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
