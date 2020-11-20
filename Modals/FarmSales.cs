using System;
using System.ComponentModel.DataAnnotations;

namespace AnabizFarmSales.Modals
{
   public class FarmSale
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string PigType { get; set; }

        [Required]
        [MaxLength(10)]
        public int NoOfPigs { get; set; }

        [Required]
        [MaxLength(255)]
        public string Amount { get; set; }

        [Required]
        [MaxLength(12)]
        public string TotalWeight { get; set; }

        public string Age { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


       // public ICollection<FarmSaler> FarmSalers { get; set; }
    }



    //public class FarmSaler
    //{
    //    public int Id { get; set; }

    //    public string PigType { get; set; }

    //    public int NoOfPigs { get; set; }

    //    public string Amount { get; set; }

    //    public string TotalWeight { get; set; }

    //    public string Age { get; set; }

    //    public DateTime CreatedAt { get; set; } = DateTime.Now;


    //    //public int FarmSalesId { get; set; }

    //    //public FarmSales FarmSales { get; set; }


    //    public int FarmSalesId { get; set; }

    //    public FarmSales FarmSales { get; set; }
    //}
}
