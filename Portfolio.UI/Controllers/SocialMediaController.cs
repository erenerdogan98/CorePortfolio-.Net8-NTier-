using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class SocialMediaController(ISocialMediaService socialMediaService) : Controller
    {
        [HttpGet("get-socialmedias")]
        public async Task<IActionResult> GetSocialMedias()
        {
            var values = await socialMediaService.TGetAllAsync();
            return View(values);
        }

        [HttpGet("add-socialmedia")]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost("add-socialmedias")]
        public async Task<IActionResult> AddSocialMedia(SocialMediaDTO SocialMediaDTO)
        {
            // later add this , only 1 contact could add.
            await socialMediaService.TAddAsync(SocialMediaDTO);
            return RedirectToAction("GetSocialMedias");
        }
        [HttpGet("update-socialmedias/{id}")]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = socialMediaService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            return View(value);
        }
        [HttpPost("update-socialmedias")]
        public IActionResult UpdateSocialMedia(SocialMediaDTO SocialMediaDTO)
        {
            socialMediaService.TUpdate(SocialMediaDTO);
            return RedirectToAction("GetSocialMedias");
        }
        [HttpGet("delete-socialmedias/{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = socialMediaService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            await socialMediaService.TDeleteAsync(value);
            return RedirectToAction("GetSocialMedias");
        }
    }
}
