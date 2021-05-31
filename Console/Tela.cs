using System;
using DIO.Bank.Entities;
using DIO.Bank.Interfaces;
using DIO.Bank.Exceptions;
using DIO.Bank.Enums;
using System.Collections.Generic;
using System.Linq;

namespace DIO.Bank.ConsoleApp
{
    public class App
    {
        private HashSet<IConta> Contas;
        private readonly IContaCorrenteService contaCorrenteService;
        private int GeradorIdsConta = 2021;
        public App(HashSet<IConta> contas, IContaCorrenteService _contaCorrenteService)
        {
            Contas = contas;
            contaCorrenteService = _contaCorrenteService;
        }
        public static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            decimal valorDeposito = decimal.Parse(Console.ReadLine());

            Contas.Where(c => c.Id == idConta).SingleOrDefault().Depositar(valorDeposito);
        }

        public void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            decimal valorSaque = decimal.Parse(Console.ReadLine());

            Contas.Where(c => c.Id == idConta).SingleOrDefault().Sacar(valorSaque);
        }

        public void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int idContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int idContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            decimal valorTransferencia = decimal.Parse(Console.ReadLine());

            Console.Write("1- TED || 2- DOC");
            EnumTranferenciaCC tranferenciaCC = (EnumTranferenciaCC)Enum.Parse(typeof(EnumTranferenciaCC), Enum.GetName(typeof(EnumTranferenciaCC), int.Parse(Console.ReadLine())));

            IConta contaOrigem = Contas.Where(c => c.Id == idContaOrigem).SingleOrDefault();

            if (!(contaOrigem.GetType() != typeof(ContaCorrente)))
            {
                Console.WriteLine("Operação Invalida a Conta de Origem deve ser uma Conta Corrente");
                return;
            }

            IConta contaDestino = Contas.Where(c => c.Id == idContaDestino).SingleOrDefault();

            contaCorrenteService.contaCorrente = (ContaCorrente)contaOrigem;

            try
            {
                if (tranferenciaCC == EnumTranferenciaCC.DOC)
                {
                    contaCorrenteService.DOC(valorTransferencia, contaDestino);
                }
                else if (tranferenciaCC == EnumTranferenciaCC.TED)
                {
                    contaCorrenteService.TED(valorTransferencia, contaDestino);
                }
                else return;
            }
            catch (ServiceException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            EnumCliente entradaTipoCliente = (EnumCliente)Enum.Parse(typeof(EnumCliente), Enum.GetName(typeof(EnumCliente), int.Parse(Console.ReadLine())));

            Cliente cliente;
            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            DateTime dataRegistro = DateTime.Now;

            Console.Write("Data de nascimento / criação do Cliente (dd/MM/yyyy): ");
            DateTime dataOrigemCliente = DateTime.Parse(Console.ReadLine());

            if (entradaTipoCliente == EnumCliente.Fisico)
            {
                Console.Write("Digite o CPF do Cliente: ");
                string cpf = Console.ReadLine();
                cliente = new ClienteFisico(entradaNome, dataRegistro, cpf, dataOrigemCliente);
            }
            else if (entradaTipoCliente == EnumCliente.Juridico)
            {
                Console.Write("Digite o CNPJ do Cliente: ");
                string cnpj = Console.ReadLine();
                cliente = new ClienteJuridico(entradaNome, dataRegistro, cnpj, dataOrigemCliente);
            }
            else return;

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite 1-Conta Corrente, 2-Conta Poupança: ");
            EnumConta entradaTipoConta = (EnumConta)Enum.Parse(typeof(EnumConta), Enum.GetName(typeof(EnumConta), int.Parse(Console.ReadLine())));

            if (entradaTipoConta == EnumConta.Corrente)
            {
                Console.Write("Digite o crédito: ");
                double entradaCredito = double.Parse(Console.ReadLine());
                Console.Write("Digite 1-Plano Comum, 2-Plano Especial, 3-Plano VIP: ");
                EnumPlanoCC entradaPlanoConta = (EnumPlanoCC)Enum.Parse(typeof(EnumPlanoCC), Enum.GetName(typeof(EnumPlanoCC), int.Parse(Console.ReadLine() + 1)));
                Contas.Add(new ContaCorrente(GeradorIdsConta++, cliente, entradaPlanoConta));
                return;
            }

            Contas.Add(new ContaPoupanca(GeradorIdsConta++, cliente));

        }

        public void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (Contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            foreach (IConta conta in Contas)
            {
                Console.WriteLine(conta);
            }
        }
    }
}