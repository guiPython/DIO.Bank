using System;
using DIO.Bank.ConsoleApp;
using DIO.Bank.Services;
using DIO.Bank.Interfaces;
using DIO.Bank.Factories;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        private static HashSet<IConta> Contas = new HashSet<IConta>();
        private static readonly ITaxaContaCorrenteService taxaContaCorrenteService = new CalculoTaxaContaCorrenteFactory();
        private static IContaCorrenteService contaCorrenteService;
        private static App Application;
        private static string OpcaoUsuario;
        static void Main(string[] args)
        {
            contaCorrenteService = new ContaCorrenteService(taxaContaCorrenteService);
            Application = new App(Contas, contaCorrenteService);
            OpcaoUsuario = App.Menu();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        Application.ListarContas();
                        break;
                    case "2":
                        Application.InserirConta();
                        break;
                    case "3":
                        Application.Transferir();
                        break;
                    case "4":
                        Application.Sacar();
                        break;
                    case "5":
                        Application.Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = App.Menu();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

    }
}

