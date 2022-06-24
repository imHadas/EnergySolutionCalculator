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
                    CpId = 1,
                    Name = "Szerelési anyagköltsség/panel",
                    Price = 23000
                },
                new ConstantPrice
                {
                    CpId = 2,
                    Name = "Munkadíj 20>=",
                    Price = 400000
                },
                new ConstantPrice
                {
                    CpId = 3,
                    Name = "Munkadíj/panel 20<x<=30",
                    Price = 15000
                },
                new ConstantPrice
                {
                    CpId = 4,
                    Name = "Munkadíj 30<x<=50",
                    Price = 580000
                },
                new ConstantPrice
                {
                    CpId = 5,
                    Name = "Munkadíj/panel 50<x<=75",
                    Price = 16000
                },
                new ConstantPrice
                {
                    CpId = 6,
                    Name = "Kiszállítás",
                    Price = 20000
                },
                new ConstantPrice
                {
                    CpId = 7,
                    Name = "Tervezési költség",
                    Price = 40000
                },
                new ConstantPrice
                {
                    CpId = 8,
                    Name = "Panel",
                    Price = 63000
                }
            };

            context.AddRange(constantPrices);
            context.SaveChanges();
        }
    }
}
