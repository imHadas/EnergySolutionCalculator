using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnergySolutionCalculator.Web.Models
{
    public class CalculatorViewModel
    {
        [DisplayName("Panelek száma")]
        [Range(0,int.MaxValue,ErrorMessage ="Csak pozitív számok vihetők be!")]
        public int NumberOfPanels { get; set; }
        public IEnumerable<Inverter>? Inverters { get; set; }
        public IEnumerable<ConstantPrice>? ConstantPrices { get; set; }
    }
}
