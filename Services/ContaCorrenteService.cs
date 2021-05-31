using DIO.Bank.Interfaces;
using DIO.Bank.Exceptions;
using DIO.Bank.Entities;
using System;

namespace DIO.Bank.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private ContaCorrente _contaCorrente;
        public ContaCorrente contaCorrente { get => contaCorrente; set => _contaCorrente = value; }
        private readonly ITaxaContaCorrenteService taxaContaCorrente;

        public ContaCorrenteService(ITaxaContaCorrenteService _taxaContaCorrente)
        {
            taxaContaCorrente = _taxaContaCorrente;
        }
        public ContaCorrenteService(ContaCorrente contaCorrente, ITaxaContaCorrenteService _taxaContaCorrente)
        {
            taxaContaCorrente = _taxaContaCorrente;
            _contaCorrente = contaCorrente;
        }
        public void DOC(decimal valorTransferencia, IConta contaDestino)
        {
            try
            {
                var taxaContaDOC = taxaContaCorrente.GetCalculoTaxaContaCorrenteService(contaCorrente.Plano).AplicarTaxaDOC(valorTransferencia, contaCorrente);
                contaCorrente.Sacar(valorTransferencia + taxaContaDOC);
                contaDestino.Depositar(valorTransferencia);
            }
            catch (FactoryException)
            {
                throw new ServiceException("");
            }
            catch (EntityException)
            {
                throw new ServiceException("");
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
            catch (FactoryException)
            {
                throw new ServiceException("");
            }
            catch (EntityException)
            {
                throw new ServiceException("");
            }
        }
    }
}