using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
