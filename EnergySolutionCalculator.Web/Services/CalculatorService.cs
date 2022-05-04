using EnergySolutionCalculator.Web.Models;

namespace EnergySolutionCalculator.Web.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly CalculatorDbContext _context;

        public CalculatorService(CalculatorDbContext context)
        {
            _context = context;
        }
        
        public List<Inverter> GetInverters()
        {
            return _context.Inverters.ToList();
        }
        public List<Inverter> GetInvertersBetween(int nop)
        {
            return _context.Inverters.Where(i => i.MinNumberOfPanels <= nop && i.MaxNumberOfPanels >= nop).ToList();
        }

        public List<Inverter> GetInvertersByUserId(int id)
        {
            return _context.Inverters.Where(i => i.UserId == id).ToList();
        }
        public Inverter? GetInverterByName(string name)
        {
            return _context.Inverters.FirstOrDefault(i => i.Name == name);
        }
        public Inverter? GetInverter(int id)
        {
            return _context.Inverters.FirstOrDefault(i => i.Id == id);
        }
        public List<ConstantPrice> GetConstantPrices()
        {
            return _context.ConstantPrices.ToList();
        }
        public ConstantPrice? GetConstantPrice(int id)
        {
            return _context.ConstantPrices.FirstOrDefault(c=>c.Id == id);
        }
        public bool UpdateUser(ApplicationUser user)
        {
            try
            {
                _context.Update(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool AddInverter(Inverter inverter)
        {
            try
            {
                _context.Add(inverter);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateInverter(Inverter inverter)
        {
            try
            {
                _context.Update(inverter);
                _context.SaveChanges();
            }
            catch(Exception ex)
            { 
                return false; 
            }
            return true;
        }
        public bool DeleteInverter(int id)
        {
            var inverter = _context.Inverters.Find(id);
            if (inverter is null)
                return false;
            try
            {
                _context.Remove(inverter);
                _context.SaveChanges();
            }
            catch (Exception)
            { return false;}
            return true;
        }
        public bool UpdatePrice(ConstantPrice constantPrice)
        {
            try
            {
                _context.Update(constantPrice);
                _context.SaveChanges();
            }
            catch (Exception)
            { 
                return false; 
            }
            return true;
        }
    }
}
