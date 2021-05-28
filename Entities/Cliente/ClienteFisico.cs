using System;

namespace DIO.Bank.Entities
{
    public class ClienteFisico : Cliente
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public ClienteFisico(int id, string nome, DateTime dataRegistro, string cpf, DateTime dataNascimento)
            : base(id, nome, dataRegistro)
        {
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
    }
}