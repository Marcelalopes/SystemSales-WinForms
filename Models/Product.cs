using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSales.Models
{
    class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(13)]
        public string CodeEAN { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public List<Sale> sales { get; set; }
    }
}
