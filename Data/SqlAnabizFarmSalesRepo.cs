using System;
using System.Collections.Generic;
using System.Linq;
using AnabizFarmSales.Modals;

namespace AnabizFarmSales.Data
{
    public class SqlAnabizFarmSalesRepo : IAnabizFarmSalesRepo
    {

        private readonly AnabizFarmSalesContext _context;


        public SqlAnabizFarmSalesRepo(AnabizFarmSalesContext context)
        {
            _context = context;
        }

        public void CreateFarmSale(FarmSale cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.FarmSales.Add(cmd);
        }


        public IEnumerable<FarmSale> GetAllSales()
        {
            return _context.FarmSales.ToList();
        }


        public FarmSale GetSalesById(int id)
        {
            return _context.FarmSales.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
