using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnergySolutionCalculator.Web.Models
{
    public class ConstantPrice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Név")]
        public string Name { get; set; } = null!;
        [Required]
        [DisplayName("Alap ár")]
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
