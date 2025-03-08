using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;

namespace Prueba_Kevin.Models
{
    public static class MenuOptions
    {
        public static WorkContext context;
        public static void MainMenu()
        {
            Console.WriteLine("Seleccione una opciòn del menu.");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Crear Cuenta");
            Console.WriteLine("3. Depositar");
            Console.WriteLine("4. Retirar");
            Console.Write("Eliga su opcion: ");
            string selectedOption = Console.ReadLine();
            MainMenuValidation(selectedOption);
        }

        public static void MainMenuValidation(string SelectedOption)
        {
            Validations validation = new Validations();
            Actions Action = new Actions();
            context = new WorkContext();
            switch (SelectedOption)
            {
                case "1":
                    {
                        Action.MenuCrearCliente();
                        break;
                    }
                case "2":
                    {
                       Action.MenuCrearCuenta();
                        break;
                    }
                case "3":
                    {
                        Action.MenuDepositar();
                        break;
                    }
                case "4":
                    {
                        Action.MenuRetirar();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Debe elegir una opcion Correcta.");
                        MainMenu();
                        break;
                    }

            }
        }


        public static void AccountTypeOptions(Client cliente)
        {
            Accounts account = new Accounts();
            Console.WriteLine("Eliga el tipo de cuenta que desea crear.");
            Console.WriteLine("1. Cuenta Corriente");
            Console.WriteLine("2. Cuenta Ahorro");
            string AccountSelected = Console.ReadLine();
            Console.Clear();
            switch (AccountSelected)
            {
                case "1":
                    {
                        account.idTypeAccount = 1;
                        account.idClient = cliente.IdClient;
                        Random random = new Random();
                        long randomNumber = (long)(random.NextDouble() * Math.Pow(10, 16));
                        account.AccountNumber = "0191" + randomNumber.ToString().PadLeft(16, '0');
                        account.swActive = true;
                        account.CrearCuenta(account);
                        Console.WriteLine("Su cuenta fue creada satisfactoriamente: " + account.AccountNumber);
                        MenuOptions.MainMenu();
                        break;
                    }
                case "2":
                    {
                        account.idTypeAccount = 2;
                        account.idClient = cliente.IdClient;
                        Random random = new Random();
                        long randomNumber = (long)(random.NextDouble() * Math.Pow(10, 16));
                        account.AccountNumber = "0191" + randomNumber.ToString().PadLeft(16, '0');
                        account.CrearCuenta(account);
                        Console.WriteLine("Su cuenta fue creada satisfactoriamente: " + account.AccountNumber);
                        MenuOptions.MainMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No ingreso un tipo de cuenta valido.");
                        AccountTypeOptions(cliente);
                        break;
                    }

            }
        }

    }
}
