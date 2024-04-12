using Microsoft.AspNetCore.Mvc;

namespace Portfolio.UI.ViewComponents.LayoutViewComponents
{
	public class LayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
