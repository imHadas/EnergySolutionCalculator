using EnergySolutionCalculator.Web.Models;

namespace EnergySolutionCalculator.Web.Services
{
    public interface ICalculatorService
    {
        List<Inverter> GetInverters();
        List<Inverter> GetInvertersBetween(int nop);
        List<ConstantPrice> GetConstantPrices();
        Inverter? GetInverterByName(string name);
        Inverter? GetInverter(int id);
        ConstantPrice? GetConstantPrice(int id);
        bool UpdateUser(ApplicationUser user);
        bool AddInverter(Inverter inverter);
        bool UpdateInverter(Inverter inverter);
        bool DeleteInverter(int id);
        bool UpdatePrice(ConstantPrice price);
    }
}
