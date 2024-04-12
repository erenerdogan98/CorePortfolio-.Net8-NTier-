using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("Experience")]
    public class ExperienceController(IExperienceService experienceService) : Controller
    {
        [HttpGet("experiences")]
        public async Task<IActionResult> Experiences()
        {
            var values = await experienceService.TGetAllAsync();
            return View(values);
        }
        [HttpGet("add-experience")]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost("add-experience")]
        public async Task<IActionResult> AddExperience(ExperienceDTO experience)
        {
            await experienceService.TAddAsync(experience);
            return RedirectToAction("Experiences");
        }
        [HttpGet("delete-experience/{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var value = await experienceService.TGetByIdAsync(id);
            if (value == null)
                return NotFound($"Experience Not Found! with id: {id}");
            await experienceService.TDeleteAsync(value);
            return RedirectToAction("Experiences");
        }
        [HttpGet("update-experience/{id}")]
        public IActionResult UpdateExperience(int id)
        {
            var experience = experienceService.TGetById(id);
            if (experience == null)
                return NotFound($"Experience Not Found! with id: {id}");
            return View(experience);
        }
        [HttpPost("update-experience")]
        public IActionResult UpdateExperience(ExperienceDTO experience)
        {
            experienceService.TUpdate(experience);
            return RedirectToAction("Experiences");
        }
    }
}
