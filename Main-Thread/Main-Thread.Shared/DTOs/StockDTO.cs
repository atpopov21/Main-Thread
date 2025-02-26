using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Thread.Shared.DTOs
{
    class StockDTO
    {
        [Required]
        [MaxLength(20)]
        public string Product { get; set; }

        [Required]
        [MaxLength(8)]
        public double Price { get; set; }

        [Required]
        [MaxLength(5)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(5)]
        public int Sold { get; set; }
    }
}
