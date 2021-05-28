using System;

namespace DIO.Bank.Entities
{
    public class ClienteJuridico : Cliente
    {
        public string CNPJ { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public ClienteJuridico(int id, string nome, DateTime dataRegistro, string cnpj, DateTime dataCriacao)
            : base(id, nome, dataRegistro)
        {
            CNPJ = cnpj;
            DataCriacao = dataCriacao;
        }
    }
}