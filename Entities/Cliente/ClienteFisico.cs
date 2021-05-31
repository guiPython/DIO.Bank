using System;

namespace DIO.Bank.Entities
{
    public class ClienteFisico : Cliente
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public ClienteFisico(string nome, DateTime dataRegistro, string cpf, DateTime dataNascimento)
            : base(nome, dataRegistro)
        {
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
    }
}