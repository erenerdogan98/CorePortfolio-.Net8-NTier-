using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;

namespace Portfolio.UI.ViewComponents.LayoutViewComponents
{
	public class LayoutNavbarComponentPartial(IToDoListService toDoListService) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync() // if use async keyword , should change method name to InvokeAsync
		{
			var toDosFalse = await toDoListService.TGetAllAsync(x => x.Status == false);
			ViewBag.toDoListCount = toDosFalse.Count();
			return View(toDosFalse);
		}
	}
}
