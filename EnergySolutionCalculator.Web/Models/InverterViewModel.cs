using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnergySolutionCalculator.Web.Models
{
    public class InverterViewModel
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
        [DisplayName("EUR")]
        [Precision(18, 2)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal PriceEur { get; set; }

        public static explicit operator Inverter(InverterViewModel vm) => new Inverter
        {
            Id = vm.Id,
            Name = vm.Name,
            Size = vm.Size,
            Amps = vm.Amps,
            MinNumberOfPanels = Convert.ToInt32(Math.Ceiling(vm.Size*(decimal)(0.8/0.375))),
            MaxNumberOfPanels = Convert.ToInt32(Math.Floor(vm.Size * (decimal)(1.2 / 0.375))),
            PriceEur = vm.PriceEur,
            PriceHuf = vm.PriceEur * 380
        };

        public static explicit operator InverterViewModel(Inverter inv) => new InverterViewModel
        {
            Id = inv.Id,
            Name = inv.Name,
            Size = inv.Size,
            Amps = inv.Amps,
            PriceEur = inv.PriceEur
        };
    }
}
