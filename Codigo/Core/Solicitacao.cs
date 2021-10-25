using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Solicitacao
    {
        public Solicitacao()
        {
            Comentario = new HashSet<Comentario>();
            Solicitacaoitem = new HashSet<Solicitacaoitem>();
        }

        public int IdSolicitacao { get; set; }
        public DateTime? Data { get; set; }
        public string Status { get; set; }
        public int IdPessoa { get; set; }
        public int IdOrganizacao { get; set; }
        public int Quantidade { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Solicitacaoitem> Solicitacaoitem { get; set; }
    }
}
