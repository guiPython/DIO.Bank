using DIO.Bank.Entities.Services;
using DIO.Bank.Interfaces;
using DIO.Bank.Enums;
using DIO.Bank.Exceptions;

namespace DIO.Bank.Factories
{
    public class CalculoTaxaContaCorrenteFactory : ITaxaContaCorrenteService
    {
        public ICalculoTaxaContaCorrente GetCalculoTaxaContaCorrenteService(EnumPlanoCC planoContaCorrente)
        {
            switch (planoContaCorrente)
            {
                case EnumPlanoCC.Comum:
                    return new ContaCorrenteComum();
                case EnumPlanoCC.Especial:
                    return new ContaCorrenteEspecial();
                case EnumPlanoCC.Vip:
                    return new ContaCorrenteVip();
                default:
                    throw new FactoryException("planoContaCorrente invalido.");
            }
        }
    }
}