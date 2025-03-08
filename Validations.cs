using Microsoft.EntityFrameworkCore;
using Prueba_Kevin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prueba_Kevin
{
    public class Validations
    {
       
        public string DocumentNumberValidation()
        {
            string DocumentNumber = "";
            bool valid = false;
            while (!valid)
            {
                DocumentNumber = Console.ReadLine();
                int ValidDocumentNumber = 0;

                if (string.IsNullOrEmpty(DocumentNumber))
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar algún valor.");
                }
                else if (!int.TryParse(DocumentNumber, out ValidDocumentNumber))
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar un numero.");
                }
                else
                {
                    valid = true;
                }
            }
            return DocumentNumber;
        }


    }
}
