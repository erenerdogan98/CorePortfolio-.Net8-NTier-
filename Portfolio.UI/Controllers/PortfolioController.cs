using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class PortfolioController(IMyPortfolioService portfolioService) : Controller
    {
        [HttpGet("get-portfolios")]
        public async Task<IActionResult> GetPortfolios()
        {
            var values = await portfolioService.TGetAllAsync();
            return View(values);
        }

        [HttpGet("add-portfolio")]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost("add-portfolio")]
        public async Task<IActionResult> AddPortfolio(MyPortfolioDTO portfolioDTO)
        {
            // later add this , only 1 contact could add.
            await portfolioService.TAddAsync(portfolioDTO);
            return RedirectToAction("GetPortfolios");
        }
        [HttpGet("update-portfolio/{id}")]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = portfolioService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            return View(value);
        }
        [HttpPost("update-portfolio")]
        public IActionResult UpdatePortfolio(MyPortfolioDTO portfolioDTO)
        {
            portfolioService.TUpdate(portfolioDTO);
            return RedirectToAction("GetPortfolios");
        }
        [HttpGet("delete-portfolio/{id}")]
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            var value = portfolioService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            await portfolioService.TDeleteAsync(value);
            return RedirectToAction("GetPortfolios");
        }
    }
}
