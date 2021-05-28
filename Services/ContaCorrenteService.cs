using DIO.Bank.Interfaces;
using DIO.Bank.Entities;
using System;

namespace DIO.Bank.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly ContaCorrente contaCorrente;
        private readonly ITaxaContaCorrenteService taxaContaCorrente;
        public ContaCorrenteService(ContaCorrente _contaCorrente, ITaxaContaCorrenteService _taxaContaCorrente)
        {
            taxaContaCorrente = _taxaContaCorrente;
            contaCorrente = _contaCorrente;
        }
        public void DOC(decimal valorTransferencia, IConta contaDestino)
        {
            try
            {
                var taxaContaDOC = taxaContaCorrente.GetCalculoTaxaContaCorrenteService(contaCorrente.Plano).AplicarTaxaDOC(valorTransferencia, contaCorrente);
                contaCorrente.Sacar(valorTransferencia + taxaContaDOC);
                contaDestino.Depositar(valorTransferencia);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void TED(decimal valorTransferencia, IConta contaDestino)
        {
            try
            {
                var taxaContaTED = taxaContaCorrente.GetCalculoTaxaContaCorrenteService(contaCorrente.Plano).AplicarTaxaTED(valorTransferencia, contaCorrente);
                contaCorrente.Sacar(valorTransferencia + taxaContaTED);
                contaDestino.Depositar(valorTransferencia);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}