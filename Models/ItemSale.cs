using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSales.Models
{
    class ItemSale
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public Sale sale { get; set; }
        public Product product { get; set; }
    }
}
