using System;
using System.ComponentModel.DataAnnotations;

namespace AnabizFarmSales.Dtos
{
    public class AnabizFarmSalesCreateDto
    {

        [Required]
        public string PigType { get; set; }

        [Required]
        public int NoOfPigs { get; set; }

        [Required]
        public string Amount { get; set; }

        [Required]
        public string TotalWeight { get; set; }

        public string Age { get; set; }

       

    }
}
