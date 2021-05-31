
namespace DIO.Bank.Interfaces
{
    public interface IConta
    {
        int Id { get; }
        void Sacar(decimal valor);
        void Depositar(decimal valor);
    }
}