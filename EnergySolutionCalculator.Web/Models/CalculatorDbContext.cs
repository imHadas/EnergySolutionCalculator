using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnergySolutionCalculator.Web.Models
{
    public class CalculatorDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int> ,int>
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
        }

        public DbSet<Inverter> Inverters { get; set; } = null!;
        public DbSet<ConstantPrice> ConstantPrices { get; set; } = null!;
    }
}
