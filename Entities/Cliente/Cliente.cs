using System;

namespace DIO.Bank.Entities
{
    public abstract class Cliente
    {
        public string Nome { get; protected set; }
        public DateTime DataRegistro { get; protected set; }
        public Cliente(string nome, DateTime dataRegistro)
        {
            Nome = nome;
            DataRegistro = dataRegistro;
        }

    }
}