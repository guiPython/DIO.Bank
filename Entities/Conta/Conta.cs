
namespace DIO.Bank.Entities
{
    public abstract class Conta
    {
        public int Id { get; protected set; }
        public Cliente Cliente { get; protected set; }
        public decimal Saldo { get; protected set; }
        public Conta(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
            Saldo = 0.0m;
        }
        public Conta(int id, Cliente cliente, decimal saldo)
        {
            Id = id;
            Cliente = cliente;
            Saldo = saldo;
        }
    }
}