using EnergySolutionCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnergySolutionCalculator.Web.Controllers
{
    public class PartialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
