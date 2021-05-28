using DIO.Bank.Interfaces;

namespace DIO.Bank.Entities.Services
{
    class ContaCorrenteVip : ICalculoTaxaContaCorrente
    {
        public decimal AplicarTaxaDOC(decimal valorTransferencia, ContaCorrente contaCorrente)
        {
            //Verificar DataCriacao da Conta, Limite de DOCs para gerar a taxa
            return 0.0m;
        }

        public decimal AplicarTaxaTED(decimal valorTransferencia, ContaCorrente contaCorrente)
        {
            //Verificar DataCriacao da Conta, Limite de TEDs para gerar a taxa
            return 0.0m;
        }
    }
}