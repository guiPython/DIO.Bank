using DIO.Bank.Interfaces;
using DIO.Bank.Exceptions;

namespace DIO.Bank.Entities
{
    public class ContaPoupanca : Conta, IConta
    {
        public ContaPoupanca(int id, Cliente cliente)
            : base(id, cliente) { }
        public ContaPoupanca(int id, Cliente cliente, decimal saldo)
            : base(id, cliente, saldo) { }

        public void Sacar(decimal valorSaque)
        {
            if (valorSaque > Saldo) throw new EntityException("O valor de Saque nao pode ultrapassar o seu Saldo.");
            else Saldo -= valorSaque;
        }

        public void Depositar(decimal valorDeposito)
        {
            if (valorDeposito < 0.0m) throw new EntityException("O valor de Deposito nao pode ser menor que 0.");
            else Saldo += valorDeposito;
        }
    }
}