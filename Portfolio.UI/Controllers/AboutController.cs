using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class AboutController(IAboutService aboutService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await aboutService.TGetAllAsync();
            return View(values);
        }
        [HttpGet("add-about")]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost("add-about")]
        public async Task<IActionResult> AddAbout(AboutDTO aboutDTO)
        {
            await aboutService.TAddAsync(aboutDTO);
            return RedirectToAction("Index");
        }
        [HttpGet("update-about/{id}")]
        public IActionResult UpdateAbout(int id)
        {
            var value = aboutService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            return View(value);
        }
        [HttpPost("update-about")]
        public IActionResult UpdateAbout(AboutDTO aboutDTO)
        {
             aboutService.TUpdate(aboutDTO);
            return RedirectToAction("Index");
        }
        [HttpGet("delete-about/{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var value = aboutService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            await aboutService.TDeleteAsync(value);
            return RedirectToAction("Index");
        }
    }
}
