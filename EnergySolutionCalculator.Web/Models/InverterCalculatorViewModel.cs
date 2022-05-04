using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergySolutionCalculator.Web.Models
{
    public class InverterCalculatorViewModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Panelszám")]
        public int NumberOfPanels { get; set; }
        [Required]
        [DisplayName("Inverter")]
        public string Name { get; set; } = null!;
        [DisplayName("Méret")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal Size { get; set; }
        [DisplayName("Amperigény")]
        public string Amps { get; set; } = null!;
        [DisplayName("Min panelszám")]
        public int MinNumberOfPanels { get; set; }
        [DisplayName("Max panelszám")]
        public int MaxNumberOfPanels { get; set; }
        
        [DisplayName("HUF")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal PriceHuf { get; set; }
        [DisplayName("Teljesítmény")]
        [Precision(18, 2)]
        public decimal Output { get; set; }
        [DisplayName("Méret (nm)")]
        [Precision(18, 2)]
        public decimal PanelSize { get; set; }
        [DisplayName("Szerelési anyagköltség netto/panel")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Precision(18, 2)]
        public decimal MaterialCost { get; set; }
        [DisplayName("Munkadíj netto")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Precision(18, 2)]
        public decimal WorkCost { get; set; }
        [DisplayName("Kiszállítás netto")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Precision(18, 2)]
        public decimal ShippingCost { get; set; }
        [DisplayName("Tervezési költség")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal PlanningCost { get; set; }
        [DisplayName("Panel netto")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal PanelCost { get; set; }
        [DisplayName("Rendszerár brutto")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal FullCost { get; set; }
    }
}
