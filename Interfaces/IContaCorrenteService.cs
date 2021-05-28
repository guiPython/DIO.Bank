using DIO.Bank.Entities;

namespace DIO.Bank.Interfaces
{
    public interface IContaCorrenteService
    {
        void TED(decimal valorTransferencia, IConta contaDestino);
        void DOC(decimal valorTransferencia, IConta contaDestino);
    }
}