using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Organizacao
    {
        public Organizacao()
        {
            Agendamento = new HashSet<Agendamento>();
            Item = new HashSet<Item>();
            Solicitacao = new HashSet<Solicitacao>();
            Vagashorarios = new HashSet<Vagashorarios>();
        }

        public int IdOrganizacao { get; set; }
        public string NomeOrganizacao { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string NumeroEndereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Agendamento> Agendamento { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
        public virtual ICollection<Vagashorarios> Vagashorarios { get; set; }
    }
}
