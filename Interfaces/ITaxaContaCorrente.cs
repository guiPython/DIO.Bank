using DIO.Bank.Enums;

namespace DIO.Bank.Interfaces
{
    public interface ITaxaContaCorrenteService
    {
        ICalculoTaxaContaCorrente GetCalculoTaxaContaCorrenteService(EnumPlanoCC planoContaCorrente);
    }
}