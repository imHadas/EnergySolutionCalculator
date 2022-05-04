using Microsoft.EntityFrameworkCore;

namespace EnergySolutionCalculator.Web.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CalculatorDbContext context)
        {
            context.Database.Migrate();

            if (context.ConstantPrices.Any())
                return;

            IList<ConstantPrice> constantPrices = new List<ConstantPrice>()
            {
                new ConstantPrice
                {
                    Name = "Szerelési anyagköltsség nettó/panel",
                    Price = 25500
                },
                new ConstantPrice
                {
                    Name = "Munkadíj nettó",
                    Price = 100000
                },
                new ConstantPrice
                {
                    Name = "Kiszállítás nettó",
                    Price = 25000
                },
                new ConstantPrice
                {
                    Name = "Tervezési költség",
                    Price = 60000
                },
                new ConstantPrice
                {
                    Name = "Panel netto",
                    Price = 44000
                }
            };

            context.AddRange(constantPrices);
            context.SaveChanges();
        }
    }
}
