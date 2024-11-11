using Microsoft.AspNetCore.Mvc;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Services;
namespace NetRom.Weather.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cityService;

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _cityService.GetAllAsync();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityModelForCreation cityModelForCreation)
        {
            await _cityService.CreateAsync(cityModelForCreation);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _cityService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(CityModel cityModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(cityModel);
            }

            var result = await _cityService.UpdateAsync(cityModel);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _cityService.GetByIdAsync(id);

            return View(model);
        }
    }
}