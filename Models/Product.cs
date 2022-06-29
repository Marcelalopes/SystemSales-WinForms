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
        /// <summary>
        /// Product class constructor
        /// </summary>
        /// <param name="codeEAN">variable to store product code EAN</param>
        /// <param name="name">variable to store product name</param>
        /// <param name="price">variable to store product price</param>
        /// <param name="inventory">variable to store product inventory</param>
        public Product(string codeEAN, string name, double price, int inventory)
        {
            CodeEAN = codeEAN;
            Name = name;
            Price = price;
            Inventory = inventory;
        }

        /// <summary>
        /// builder to store cart list
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="price">product price</param>
        public Product(int id, double price)
        {
            Id = id;
            Price = price;
        }

        /// <summary>
        /// Product ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(13)]
        public string CodeEAN { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }

        /// <summary>
        /// Sales list
        /// </summary>
        public List<Sale> sales { get; set; }
    }
}
