using DIO.Bank.Entities;
using System;

namespace DIO.Bank.Extensions
{
    public static class ContaCorrenteExtensions
    {
        public static int GetTempoFidelidadeAnos(this Conta conta)
        {
            return (int)DateTime.Now.Subtract(conta.Cliente.DataRegistro).TotalDays / 360;
        }
    }
}