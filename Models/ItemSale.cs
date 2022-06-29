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
        public ItemSale(int productId, double price)
        {
            ProductId = productId;
            Price = price;
        }

        public ItemSale(int saleId, int productId, double price, int quantity, double totalValue)
        {
            SaleId = saleId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            TotalValue = totalValue;
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }
    }
}
