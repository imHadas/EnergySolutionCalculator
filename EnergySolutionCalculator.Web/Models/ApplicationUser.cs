using Microsoft.AspNetCore.Identity;

namespace EnergySolutionCalculator.Web.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<Inverter> SelectedInverters { get; set; } = null!;
    }
}
