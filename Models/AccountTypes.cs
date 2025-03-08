using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prueba_Kevin.Models
{
    public class AccountTypes
    {
        [Key]
        public int idTypeAccount { get; set; }
        public string AccountName { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? OverdraftLimit { get; set; }

    }
}
