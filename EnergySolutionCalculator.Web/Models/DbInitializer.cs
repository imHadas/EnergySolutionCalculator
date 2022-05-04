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
                    Name = "Szerelési anyagköltsség/panel",
                    Price = 23000
                },
                new ConstantPrice
                {
                    Name = "Munkadíj 20>=",
                    Price = 400000
                },
                new ConstantPrice
                {
                    Name = "Munkadíj/panel 20<x<=30",
                    Price = 15000
                },
                new ConstantPrice
                {
                    Name = "Munkadíj 30<x<=50",
                    Price = 580000
                },
                new ConstantPrice
                {
                    Name = "Munkadíj/panel 50<x<=75",
                    Price = 16000
                },
                new ConstantPrice
                {
                    Name = "Kiszállítás",
                    Price = 20000
                },
                new ConstantPrice
                {
                    Name = "Tervezési költség",
                    Price = 40000
                },
                new ConstantPrice
                {
                    Name = "Panel",
                    Price = 63000
                }
            };

            context.AddRange(constantPrices);
            context.SaveChanges();
        }
    }
}
