using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergySolutionCalculator.Web.Models
{
    public class Inverter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Inverter")]
        public string Name { get; set; } = null!;
        [DisplayName("Méret")]
        [Precision(18,2)]
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
        [ForeignKey("ApplicationUser")]
        public int? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
