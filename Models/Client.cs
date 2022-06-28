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
        public Client(string name, string cPF, string phone, string email)
        {
            Name = name;
            CPF = cPF;
            Phone = phone;
            Email = email;
        }

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
