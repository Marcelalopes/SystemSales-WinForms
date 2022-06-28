using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSales.Models
{
    class Sale
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }
        public Client client { get; set; }
        public List<Product> Products { get; set; }
    }
}
