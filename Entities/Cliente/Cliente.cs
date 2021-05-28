using System;

namespace DIO.Bank.Entities
{
    public abstract class Cliente
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DataRegistro { get; protected set; }

        public Cliente(int id, string nome, DateTime dataRegistro)
        {
            Id = id;
            Nome = nome;
            DataRegistro = dataRegistro;
        }

    }
}