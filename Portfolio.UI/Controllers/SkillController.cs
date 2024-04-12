using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class SkillController(ISkillService skillService) : Controller
    {
        [HttpGet("get-skills")]
        public async Task<IActionResult> GetSkills()
        {
            var values = await skillService.TGetAllAsync();
            return View(values);
        }

        [HttpGet("add-skill")]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost("add-skill")]
        public async Task<IActionResult> AddSkill(SkillDTO skillDTO)
        {
            // later add this , only 1 contact could add.
            await skillService.TAddAsync(skillDTO);
            return RedirectToAction("GetSkills");
        }
        [HttpGet("update-skill/{id}")]
        public IActionResult UpdateSkill(int id)
        {
            var value = skillService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            return View(value);
        }
        [HttpPost("update-skill")]
        public IActionResult UpdateSkill(SkillDTO skillDTO)
        {
            skillService.TUpdate(skillDTO);
            return RedirectToAction("GetSkills");
        }
        [HttpGet("delete-skill/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var value = skillService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            await skillService.TDeleteAsync(value);
            return RedirectToAction("GetSkills");
        }
    }
}
