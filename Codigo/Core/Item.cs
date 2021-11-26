using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Item
    {
        public Item()
        {
            Solicitacaoitem = new HashSet<Solicitacaoitem>();
        }

        public int IdItem { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int IdOrganizacao { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
        public virtual ICollection<Solicitacaoitem> Solicitacaoitem { get; set; }
        public string NomeOrganizacao { get; set; }
    }
}
