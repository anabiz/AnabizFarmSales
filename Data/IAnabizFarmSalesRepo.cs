using System.Collections.Generic;
using AnabizFarmSales.Modals;

namespace AnabizFarmSales.Data
{
    public interface IAnabizFarmSalesRepo
    {
        bool SaveChanges();

        IEnumerable<FarmSale> GetAllSales();

        FarmSale GetSalesById(int id);

        void CreateFarmSale(FarmSale cmd);

 
    }
}
