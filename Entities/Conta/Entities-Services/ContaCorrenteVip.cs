using DIO.Bank.Interfaces;
using DIO.Bank.Extensions;

namespace DIO.Bank.Entities.Services
{
    class ContaCorrenteVip : ICalculoTaxaContaCorrente
    {
        private readonly decimal TaxaDOC = 0.01m;
        private readonly decimal TaxaTED = 0.05m;
        private readonly decimal TaxaDescontoFidelidade = 0.005m;
        public decimal AplicarTaxaDOC(decimal valorTransferencia, ContaCorrente contaCorrente)
        {
            int tempoFidelidade = contaCorrente.GetTempoFidelidadeAnos();
            decimal TaxaDesconto = tempoFidelidade >= 2 ? TaxaDOC : TaxaDescontoFidelidade;
            return valorTransferencia * (TaxaDOC - TaxaDesconto);
        }

        public decimal AplicarTaxaTED(decimal valorTransferencia, ContaCorrente contaCorrente)
        {
            int tempoFidelidade = contaCorrente.GetTempoFidelidadeAnos();
            decimal TaxaDesconto = tempoFidelidade >= 4 ? TaxaTED : TaxaDescontoFidelidade;
            return valorTransferencia * (TaxaTED - TaxaDesconto);
        }
    }
}