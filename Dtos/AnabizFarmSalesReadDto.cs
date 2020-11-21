using System;
namespace AnabizFarmSales.Dtos
{
    public class AnabizFarmSalesReadDto
    {
        
        public int Id { get; set; }

        public string PigType { get; set; }

        public int NoOfPigs { get; set; }

        public string Amount { get; set; }

        public DateTime CreatedAt { get; set; }
     
    }
}
