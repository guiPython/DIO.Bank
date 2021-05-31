using DIO.Bank.Interfaces;
using DIO.Bank.Exceptions;
using DIO.Bank.Enums;

namespace DIO.Bank.Entities
{
    public class ContaCorrente : Conta, IConta
    {
        public decimal Credito { get; private set; }
        public EnumPlanoCC Plano { get; set; }
        public ContaCorrente(int id, Cliente cliente, EnumPlanoCC plano)
            : base(id, cliente)
        {
            Plano = plano;
        }
        public ContaCorrente(int id, Cliente cliente, decimal saldo, EnumPlanoCC plano)
            : base(id, cliente, saldo) { Plano = plano; }

        public void Sacar(decimal valorSaque)
        {
            if (Saldo + Credito < valorSaque) throw new EntityException("O valor de Saque nao pode ultrapassar o seu Credito.");
            else Saldo -= valorSaque;
        }

        public void Depositar(decimal valorDeposito)
        {
            if (valorDeposito < 0.0m) throw new EntityException("O valor de Deposito nao pode ser menor que 0.");
            else Saldo += valorDeposito;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}