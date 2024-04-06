using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents
{
    public class SkillComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
