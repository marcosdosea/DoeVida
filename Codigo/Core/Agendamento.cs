using System;

namespace Core
{
    public partial class Agendamento
    {
        public int IdAgendamento { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public TimeSpan HorarioAgendamento { get; set; }
        public string Descricao { get; set; }
        public int IdPessoa { get; set; }
        public int IdOrganizacao { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
