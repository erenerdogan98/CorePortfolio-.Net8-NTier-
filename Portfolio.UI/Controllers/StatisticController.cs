using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.UI.ViewModels;

namespace Portfolio.UI.Controllers
{
	public class StatisticController(IMessageService messageService,ISkillService skillService) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var messages = await messageService.TGetAllAsync();
			var messagesCount = messages.Count();
			var messagesTrue = await messageService.TGetAllAsync(x => x.IsRead == true);
			var messagesFalse = await messageService.TGetAllAsync(x => x.IsRead == false);
			var skills = await skillService.TGetAllAsync();
			//ViewBag.v1 = messagesCount;
			//ViewBag.v2 = messagesTrue.Count();
			//ViewBag.v3 = messagesFalse.Count();
			//ViewBag.v4 = skills.Count();
			var model = new StatisticViewModel
			{
				MessagesCount = messagesCount,
				MessagesTrueCount = messagesTrue.Count(),
				MessagesFalseCount = messagesFalse.Count(),
				SkillsCount = skills.Count()
			};
			return View(model);
		}
	}
}
