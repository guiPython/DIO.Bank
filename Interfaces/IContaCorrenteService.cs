using DIO.Bank.Entities;

namespace DIO.Bank.Interfaces
{
    public interface IContaCorrenteService
    {
        ContaCorrente contaCorrente { get; set; }
        void TED(decimal valorTransferencia, IConta contaDestino);
        void DOC(decimal valorTransferencia, IConta contaDestino);
    }
}