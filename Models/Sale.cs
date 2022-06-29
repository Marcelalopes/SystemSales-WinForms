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
        /// <summary>
        /// Sale class constructor
        /// </summary>
        /// <param name="clientId">variable to store client id</param>
        /// <param name="productId">variable to store product id</param>
        /// <param name="price">variable to store product value</param>
        /// <param name="quantity">variable to store quantity to be purchased</param>
        /// <param name="totalValue">variable to store the total amount of the sale</param>
        public Sale(int clientId, int productId, double price, int quantity, double totalValue)
        {
            ClientId = clientId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            TotalValue = totalValue;
        }

        /// <summary>
        /// Sale ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalValue { get; set; }

        /// <summary>
        /// Client Object
        /// </summary>
        public Client client { get; set; }

        /// <summary>
        /// Products List
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
