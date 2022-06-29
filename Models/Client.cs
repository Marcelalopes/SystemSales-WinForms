using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSales.Models
{
    class Client
    {
        /// <summary>
        /// Client class constructor
        /// </summary>
        /// <param name="name">client name</param>
        /// <param name="cPF">client cpf</param>
        /// <param name="phone">client phone</param>
        /// <param name="email">client email</param>
        public Client(string name, string cPF, string phone, string email)
        {
            Name = name;
            CPF = cPF;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Client ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(15)]
        public string CPF { get; set; }
        [Required, MaxLength(14)]
        public string Phone { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
    }
}
