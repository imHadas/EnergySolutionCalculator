using EnergySolutionCalculator.Web.Models;
using EnergySolutionCalculator.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnergySolutionCalculator.Web.Controllers
{
    public class ConstantPriceController : Controller
    {
        private readonly ICalculatorService _service;

        public ConstantPriceController(ICalculatorService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            return View(_service.GetConstantPrices());
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if(id is null)
                return NotFound();
            var price = _service.GetConstantPrice((int)id);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, ConstantPrice cp)
        {
            if (id != cp.Id)
                return NotFound();
            if(ModelState.IsValid)
            {
                var result = _service.UpdatePrice(cp);
                if (result)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Hiba mentés közben");
            }
            return View(cp);
        }
    }
}
