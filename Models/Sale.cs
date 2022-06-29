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
        /// <param name="totalValue">variable to store the total amount of the sale</param>
        public Sale(int clientId, double totalValue)
        {
            ClientId = clientId;
            TotalValue = totalValue;
        }

        /// <summary>
        /// Sale ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public double TotalValue { get; set; }
    }
}
