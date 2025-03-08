using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_Kevin.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string ClientName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        public void CrearCliente(Client client)
        {
            WorkContext context = new WorkContext();    
            context.Clientes.Add(client);
            context.SaveChanges();
        }
    }
}
