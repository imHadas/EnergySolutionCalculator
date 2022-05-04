using EnergySolutionCalculator.Web.Models;
using EnergySolutionCalculator.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnergySolutionCalculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public CalculatorController(ICalculatorService service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var vm = new CalculatorViewModel
            {
                NumberOfPanels = 0,
                Inverters = _service.GetInverters(),
                ConstantPrices = _service.GetConstantPrices()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CalculatorViewModel vm)
        {
            vm.Inverters = _service.GetInvertersBetween(vm.NumberOfPanels);
            vm.ConstantPrices = _service.GetConstantPrices();
            return View(vm);
        }
        
        public async Task<IActionResult> Fixate(int id, int nop)
        {
            var user = await _userManager.GetUserAsync(User);
            var inverter = _service.GetInverter(id);
            if (inverter is not null)
            {
                inverter.User = user;
                _service.UpdateInverter(inverter);
            }
            CalculatorViewModel vm = new CalculatorViewModel
            {
                NumberOfPanels = nop,
                Inverters = _service.GetInvertersBetween(nop),
                ConstantPrices = _service.GetConstantPrices()
            };
            return RedirectToAction("Index", vm);
        }
    }
}
