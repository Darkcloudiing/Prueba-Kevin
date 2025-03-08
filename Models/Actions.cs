using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Prueba_Kevin.Models
{
    public class Actions
    {
        Validations validation;
        WorkContext context;
        public void MenuCrearCliente()
        {

            Client client = new Client();
            Console.Clear();
            Console.WriteLine("Ingrese el Nombre del Cliente.");
            client.ClientName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ingrese el tipo de Documento de identidad");
            client.DocumentType = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ingrese el Numero de documento de identidad:");
            client.DocumentNumber = validation.DocumentNumberValidation();
            Console.Clear();
            client.CrearCliente(client);
            Console.WriteLine("El cliente fue creado exitosamente.");
            MenuOptions.MainMenu();
        }

        public void MenuCrearCuenta()
        {
            context = new WorkContext();
            Console.Clear();
            Console.WriteLine("Ingrese el Numero de documento de identidad:");
            string DocumentNumber = validation.DocumentNumberValidation();
            var cliente = context.Clientes.FirstOrDefault(x => x.DocumentNumber == DocumentNumber);
            if (cliente == null)
            {
                Console.Clear();
                Console.WriteLine("El cliente ingresado no existe, debe crearlo primero");
                MenuOptions.MainMenu();
            }
            else
            {
                Console.Clear();
                MenuOptions.AccountTypeOptions(cliente);
            }
        }

        public void MenuDepositar()
        {
            context = new WorkContext();
            validation = new Validations();
            Console.Clear();
            Console.WriteLine("Ingrese el Numero de documento de identidad:");
            string DocumentNumber = validation.DocumentNumberValidation();
            var cliente = context.Clientes.FirstOrDefault(x => x.DocumentNumber == DocumentNumber);
            if (cliente == null)
            {
                Console.Clear();
                Console.WriteLine("El cliente ingresado no existe, debe crearlo primero");
                MenuOptions.MainMenu();
            }
            else
            {
                var cuentas = context.Cuentas.Where(x => x.idClient == cliente.IdClient).ToList();
                if (!cuentas.Any())
                {
                    Console.Clear();
                    Console.WriteLine("El cliente no posee cuentas");
                    MenuOptions.MainMenu();
                }
                List<Accounts> ClientAccounts = new List<Accounts>();
                int ValidSelectedID = 0;
                string SelectedID = "";
                Console.Clear();
                bool Valid = false;
                while (!Valid)
                {
                    Console.WriteLine("Eliga la cuenta a la cual desea depositar");
                    int count = 1;
                    foreach (var item in cuentas)
                    {
                        ClientAccounts.Add(new Accounts { idAccount = count, AccountNumber = item.AccountNumber, idClient = item.idClient, Amount = item.Amount, idTypeAccount = item.idTypeAccount });
                        Console.WriteLine(count + ") " + item.AccountNumber);
                        count++;
                    }
                    SelectedID = Console.ReadLine();
                    if (!int.TryParse(SelectedID, out ValidSelectedID) || !ClientAccounts.Exists(acc => acc.idAccount == ValidSelectedID))
                    {
                        Console.ReadLine();
                        Console.WriteLine("El id seleccionado no es Valido");
                    }
                    else
                    {
                        Valid = true;
                    }
                }
                var selectedAccount = ClientAccounts.Find(account => account.idAccount == int.Parse(SelectedID));
                Console.Clear();
                Valid = false;
                string Amount = "";
                while (!Valid) 
                {
                    Console.WriteLine("Escriba el monto que desea depositar");
                    Amount = Console.ReadLine();
                    decimal ValidAmount = 0;
                    if (!decimal.TryParse(Amount, out ValidAmount))
                    {
                        Console.WriteLine("El monto no es Valido");
                    }
                    else
                    {
                        Valid = true;
                    }
                }                
                Console.Clear();
                Accounts account = new Accounts();
                account.Depositar(selectedAccount, Amount);
                Console.Clear();
                Console.WriteLine("Se ha depositado su dinero exitosamente.");
                MenuOptions.MainMenu();
            }



        }
        public void MenuRetirar()
        {
            context = new WorkContext();
            validation = new Validations();
            Console.Clear();
            Console.WriteLine("Ingrese el Numero de documento de identidad:");
            string DocumentNumber = validation.DocumentNumberValidation();
            var cliente = context.Clientes.FirstOrDefault(x => x.DocumentNumber == DocumentNumber);
            if (cliente == null)
            {
                Console.Clear();
                Console.WriteLine("El cliente ingresado no existe, debe crearlo primero");
                MenuOptions.MainMenu();
            }
            else
            {
                var cuentas = context.Cuentas.Where(x => x.idClient == cliente.IdClient).ToList();
                if (!cuentas.Any())
                {
                    Console.Clear();
                    Console.WriteLine("El cliente no posee cuentas");
                    MenuOptions.MainMenu();
                }
                List<Accounts> ClientAccounts = new List<Accounts>();
                int ValidSelectedID = 0;
                string SelectedID = "";
                Console.Clear();
                bool Valid = false;
                while (!Valid)
                {
                    Console.WriteLine("Eliga la cuenta de la cual desea retirar");
                    int count = 1;
                    foreach (var item in cuentas)
                    {
                        ClientAccounts.Add(new Accounts { idAccount = count, AccountNumber = item.AccountNumber, idClient = item.idClient, Amount = item.Amount, idTypeAccount = item.idTypeAccount });
                        Console.WriteLine(count + ") " + item.AccountNumber + " Saldo: " + item.Amount);
                        count++;
                    }
                    SelectedID = Console.ReadLine();
                    if (!int.TryParse(SelectedID, out ValidSelectedID) || !ClientAccounts.Exists(acc => acc.idAccount == ValidSelectedID))
                    {
                        Console.ReadLine();
                        Console.WriteLine("El id seleccionado no es Valido");
                    }
                    else
                    {
                        Valid = true;
                    }
                }
                var selectedAccount = ClientAccounts.Find(account => account.idAccount == int.Parse(SelectedID));
                if(selectedAccount.Amount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No puedes retirar de una cuenta sin dinero.");
                    MenuOptions.MainMenu();
                }
                Console.Clear();
                Valid = false;
                string Amount = "";
                while (!Valid)
                {
                    Console.WriteLine("Escriba el monto que desea retirar");
                    Amount = Console.ReadLine();
                    decimal ValidAmount = 0;
                    if (!decimal.TryParse(Amount, out ValidAmount))
                    {
                        Console.WriteLine("El monto no es Valido");
                    }
                    else if(decimal.Parse(Amount) > selectedAccount.Amount)
                    {
                        Console.Clear();
                        Console.WriteLine("El monto a retirar no puede ser mayor a la cantidad en la cuenta.");
                    }
                    else
                    {
                        Valid = true;
                    }
                }
                Console.Clear();
                Accounts account = new Accounts();
                account.Retirar(selectedAccount, Amount);
                Console.Clear();
                Console.WriteLine("Se ha retirado su dinero exitosamente.");
                MenuOptions.MainMenu();
            }
        }
    }
}
