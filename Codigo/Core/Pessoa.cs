using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Agendamento = new HashSet<Agendamento>();
            Comentario = new HashSet<Comentario>();
            Pessoaorganizacao = new HashSet<Pessoaorganizacao>();
            Solicitacao = new HashSet<Solicitacao>();
        }

        public int IdPessoa { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string IdUser { get; set; }

        public virtual Aspnetusers IdUserNavigation { get; set; }
        public virtual ICollection<Agendamento> Agendamento { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Pessoaorganizacao> Pessoaorganizacao { get; set; }
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}
