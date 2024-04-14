using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;
using Serilog;



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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				await aboutService.TAddAsync(aboutDTO);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				Log.Error(ex, "An error occurred while adding about information");
				return StatusCode(500, "An error occurred while processing your request. Please try again later.");
			}
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
            try
            {
				aboutService.TUpdate(aboutDTO);
				return RedirectToAction("Index");
			}
            catch (Exception ex)
            {
				Log.Error(ex, "An error occurred while updating about information");
				return StatusCode(500, "An error occurred while processing your request. Please try again later.");
				throw;
            } 
            
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
