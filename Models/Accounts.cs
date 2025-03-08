using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_Kevin.Models
{
    public class Accounts
    {
        [Key]
        public int idAccount { get; set; }
        [ForeignKey("Client")]
        public int idClient { get; set; }
        [ForeignKey("AccountTypes")]
        public int idTypeAccount { get; set; }

        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }

        public bool swActive { get; set; }

        public void CrearCuenta(Accounts account)
        {
            WorkContext context = new WorkContext();
            context.Cuentas.Add(account);
            context.SaveChanges();
        }
        public void Depositar(Accounts account, string Amount)
        {
            WorkContext context = new WorkContext();
            account.Amount = account.Amount + int.Parse(Amount);
            context.Cuentas.Update(account);
            context.SaveChanges();
        }
        public void Retirar(Accounts account, string Amount)
        {
            WorkContext context = new WorkContext();
            account.Amount = account.Amount - int.Parse(Amount);
            context.Cuentas.Update(account);
            context.SaveChanges();
        }

    }
}
