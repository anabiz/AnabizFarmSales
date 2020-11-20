using System;
using System.Collections.Generic;
using AnabizFarmSales.Modals;

namespace AnabizFarmSales.Data
{
    public class MockAnabizFarmSalesRepo : IAnabizFarmSalesRepo
    {
        public void CreateFarmSale(FarmSale cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FarmSale> GetAllSales()
        {
            var farmSales = new List<FarmSale>
            {
                new FarmSale{ Id=0, PigType="porker", NoOfPigs=1, Amount= "50000", TotalWeight="60kg",
                Age="18months"},
               new FarmSale{ Id=1, PigType="mix", NoOfPigs=1, Amount= "200000", TotalWeight="240kg",
                Age="mix"},
               new FarmSale{ Id=2, PigType="piglet", NoOfPigs=12, Amount= "120000", TotalWeight="125kg",
                Age="18months"},
               new FarmSale{ Id=3, PigType="weaners", NoOfPigs=50, Amount= "6000000", TotalWeight="500kg",
                Age="18months"},
            };

            return farmSales;
        }

        public FarmSale GetSalesById(int id)
        {
            return new FarmSale
            {
                Id = 2,
                PigType = "sow",
                NoOfPigs = 1,
                Amount = "60000",
                TotalWeight = "75kg",
                Age = "12months"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}