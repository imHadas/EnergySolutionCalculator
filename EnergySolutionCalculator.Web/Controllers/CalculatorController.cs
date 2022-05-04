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
                Inverters = MakeICVM(0)
            };
            
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CalculatorViewModel vm)
        {
            vm.Inverters = MakeICVM(vm.NumberOfPanels);
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
                Inverters = MakeICVM(nop)
            };
            return RedirectToAction("Index", vm);
        }

        private List<InverterCalculatorViewModel> MakeICVM(int nop)
        {
            decimal installDays = Math.Ceiling(nop < 20 ? 1 : (decimal)((double)nop / 20));
            List<InverterCalculatorViewModel> list = new List<InverterCalculatorViewModel>();
            foreach (var inv in _service.GetInvertersBetween(nop))
            {
                var icvm = new InverterCalculatorViewModel
                {
                    Id = inv.Id,
                    NumberOfPanels = nop,
                    Name = inv.Name,
                    Size = inv.Size,
                    Amps = inv.Amps,
                    MinNumberOfPanels = inv.MinNumberOfPanels,
                    MaxNumberOfPanels = inv.MaxNumberOfPanels,
                    PriceHuf = inv.PriceHuf,
                    Output = (decimal)(nop * 0.375),
                    PanelSize = (decimal)(nop * 1.8),
                    MaterialCost = _service.GetConstantPrice(6).Price,
                    WorkCost = nop <= 20 ? _service.GetConstantPrice(7).Price : 
                        nop <= 30 ? _service.GetConstantPrice(7).Price + _service.GetConstantPrice(8).Price * (nop - 20) : 
                        nop <= 50 ? _service.GetConstantPrice(9).Price :
                        nop <= 75 ? _service.GetConstantPrice(9).Price + _service.GetConstantPrice(10).Price * (nop - 50) : 0 ,
                    ShippingCost = _service.GetConstantPrice(11).Price * installDays,
                    PlanningCost = _service.GetConstantPrice(12).Price,
                    PanelCost = _service.GetConstantPrice(13).Price
                };
                icvm.FullCost = ((nop * icvm.MaterialCost + icvm.PriceHuf) * (decimal)1.15 +
                                 icvm.WorkCost + icvm.ShippingCost * installDays + icvm.PlanningCost) + 120000 + 266000 + (icvm.PanelCost * nop)*(decimal)1.1; //120k a tűzeseti esetleges konstans/választható opció / Mi a tököm az a 266k??
                list.Add(icvm);
            }

            return list;
        }
    }
}
