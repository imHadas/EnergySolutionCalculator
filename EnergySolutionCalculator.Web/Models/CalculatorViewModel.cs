using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnergySolutionCalculator.Web.Models
{
    public class CalculatorViewModel
    {
        [DisplayName("Panelek száma")]
        [Range(0,int.MaxValue,ErrorMessage ="Csak pozitív számok vihetők be!")]
        public int NumberOfPanels { get; set; }
        public IEnumerable<InverterCalculatorViewModel>? Inverters { get; set; }
    }
}
