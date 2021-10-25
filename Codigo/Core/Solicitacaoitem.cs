using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Solicitacaoitem
    {
        public int IdSolicitacaoItem { get; set; }
        public int IdSolicitacao { get; set; }
        public int IdItem { get; set; }

        public virtual Item IdItemNavigation { get; set; }
        public virtual Solicitacao IdSolicitacaoNavigation { get; set; }
    }
}
