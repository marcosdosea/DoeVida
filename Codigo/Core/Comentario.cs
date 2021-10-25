using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public string Texto { get; set; }
        public DateTime? Data { get; set; }
        public int IdSolicitacao { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Solicitacao IdSolicitacaoNavigation { get; set; }
    }
}
