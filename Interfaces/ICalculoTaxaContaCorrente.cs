using DIO.Bank.Entities;

namespace DIO.Bank.Interfaces
{
    public interface ICalculoTaxaContaCorrente
    {
        decimal AplicarTaxaDOC(decimal valorTransferencia, ContaCorrente contaCorrente);

        decimal AplicarTaxaTED(decimal valorTransferencia, ContaCorrente contaCorrente);
    }
}