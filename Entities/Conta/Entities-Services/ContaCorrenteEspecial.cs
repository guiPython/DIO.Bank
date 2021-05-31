using DIO.Bank.Interfaces;
using DIO.Bank.Extensions;

namespace DIO.Bank.Entities.Services
{
    class ContaCorrenteEspecial : ICalculoTaxaContaCorrente
    {
        private readonly decimal TaxaDOC = 0.02m;
        private readonly decimal TaxaTED = 0.07m;
        private readonly decimal TaxaDescontoFidelidade = 0.003m;
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