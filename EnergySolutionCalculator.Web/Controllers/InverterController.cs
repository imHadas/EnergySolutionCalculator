using EnergySolutionCalculator.Web.Models;
using EnergySolutionCalculator.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace EnergySolutionCalculator.Web.Controllers
{
    public class InverterController : Controller
    {
        private readonly ICalculatorService _service;

        public InverterController(ICalculatorService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            return View(_service.GetInverters());
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(InverterViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var inverter = (Inverter)vm;
                var result = _service.AddInverter(inverter);
                if(result)
                    return RedirectToAction("Index");
            }
            return View(vm);
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return NotFound();
            var inverter = _service.GetInverter((int)id);
            if (inverter is null)
                return NotFound();
            var vm = (InverterViewModel)inverter;
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, InverterViewModel vm)
        {
            if (id != vm.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                var inverter = (Inverter)vm;
                var result = _service.UpdateInverter(inverter);
                if (result)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Hiba a mentés során");
            }
            return View(vm);
        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();
            var inverter = _service.GetInverter((int)id);
            if (inverter is null)
                return NotFound();
            return View(inverter);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteConfirmed(int id)
        {
            var inverter = _service.GetInverter(id);
            if (inverter is null)
                return NotFound();
            _service.DeleteInverter(id);
            return RedirectToAction("Index");
        }
    }
}
