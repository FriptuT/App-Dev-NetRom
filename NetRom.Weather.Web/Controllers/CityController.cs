using Microsoft.AspNetCore.Mvc;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Services;

namespace NetRom.Weather.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        //Note: Enpoint pentru a afisa lista cu toate orasele
        public async Task<IActionResult> Index()
        {
            var result = await _cityService.GetAllAsync();
            return View(result);
        }

        //Note: Enpoint pentru a creea un nou oras
        //Note (Practice): Puteti sa adaugati server side validation pentru view model. Vedeti commentul de la Update [HttpPut]
        [HttpPost]
        public async Task<IActionResult> Create(CityModelForCreation cityModelForCreation)
        {
            await _cityService.CreateAsync(cityModelForCreation);

            return RedirectToAction(nameof(Index));
        }

        //Note: Enpoint pentru a sterge un oras 
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid cityId)
        {
            await _cityService.DeleteAsync(cityId);
            
            return RedirectToAction(nameof(Index));
        }

        //Note: Endpoint pentru a updata un oras existent
        public async Task<IActionResult> Edit(CityModel cityModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cityModel);
            }

            var result = await _cityService.UpdateAsync(cityModel);

            return RedirectToAction(nameof(Index));
        }

        //Note: Endpoint pentru a obtine view-ul de Create
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
