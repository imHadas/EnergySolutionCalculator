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
        [DisplayName("EUR")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal PriceEur { get; set; }
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
        [Precision(18, 2)]
        public decimal MaterialCost { get; set; }
        [DisplayName("Munkadíj netto")]
        [Precision(18, 2)]
        public decimal WorkCost { get; set; }
        [DisplayName("Kiszállítás netto")]
        [Precision(18, 2)]
        public decimal ShippingCost { get; set; }
        [DisplayName("Tervezési költség")]
        [Precision(18, 2)]
        public decimal PlanningCost { get; set; }
        [DisplayName("Rendszerár brutto")]
        [Precision(18, 2)]
        public decimal FullCost { get; set; }
        [ForeignKey("ApplicationUser")]
        public int? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
