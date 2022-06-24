using System.ComponentModel;

namespace EnergySolutionCalculator.Web.Models
{
    public class PartialCalculatorViewModel
    {
        [DisplayName("Villanyszámla")]
        public decimal ElectricityBill { get; set; }
        [DisplayName("Ajánlott panelszám")]
        public int RecommendedPanels { get; set; }
        [DisplayName("Termelés(kwh)")]
        public decimal Output { get; set; }
        [DisplayName("nm")]
        public decimal Size { get; set; }
    }
}
