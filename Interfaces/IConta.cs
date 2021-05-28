
namespace DIO.Bank.Interfaces
{
    public interface IConta
    {
        void Sacar(decimal valor);
        void Depositar(decimal valor);
    }
}