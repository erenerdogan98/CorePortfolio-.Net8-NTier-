using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class MessageController(IMessageService messageService) : Controller
    {
        [HttpGet("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            var values = await messageService.TGetAllAsync();
            return View(values);
        }
        [HttpGet("change-true/{id}")]
        public async Task<IActionResult> ChangeIsReadTrue(int id)
        {
            var message = await messageService.TGetByIdAsync(id);
            messageService.TChangeStatusTrue(message);
            return RedirectToAction("Inbox");
        }

        [HttpGet("change-false/{id}")]
        public async Task<IActionResult> ChangeIsReadFalse(int id)
        {
            var message = await messageService.TGetByIdAsync(id);
            messageService.TChangeStatusFalse(message);
            return RedirectToAction("Inbox");
        }

        [HttpGet("delete-message/{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        
        {
            var message = await messageService.TGetByIdAsync(id);
            await messageService.TDeleteAsync(message);
            return RedirectToAction("Inbox");
        }

        [HttpGet("message-detail/{id}")]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var message = await messageService.TGetByIdAsync(id);
            return View(message);
        }
    }
}
