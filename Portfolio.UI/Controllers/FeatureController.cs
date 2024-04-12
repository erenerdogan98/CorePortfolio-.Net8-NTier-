using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class FeatureController(IFeatureService featureService) : Controller
    {
        [HttpGet("features")]
        public async Task<IActionResult> Features()
        {
            var values = await featureService.TGetAllAsync();
            //if (!values.Any())
            //    return NotFound("Not found");
            return View(values);
        }
        [HttpGet("add-feature")]
        public IActionResult AddFeature()
        {
            return View();
        }
        [HttpPost("add-feature")]
        public async Task<IActionResult> AddFeature(FeatureDTO featureDTO)
        {
            await featureService.TAddAsync(featureDTO);
            return RedirectToAction("Features");
        }
        [HttpGet("update-feature/{id}")]
        public IActionResult UpdateFeature(int id)
        {
            var value = featureService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            return View(value);
        }
        [HttpPost("update-feature")]
        public IActionResult UpdateFeature(FeatureDTO featureDTO)
        {
            featureService.TUpdate(featureDTO);
            return RedirectToAction("Features");
        }
        [HttpGet("delete-feature/{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = featureService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            await featureService.TDeleteAsync(value);
            return RedirectToAction("Features");
        }
    }
}
