using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Vagashorarios
    {
        public int IdVagasHorarios { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFinal { get; set; }
        public int? NumeroVagas { get; set; }
        public int IdOrganizacao { get; set; }

        public virtual Organizacao IdOrganizacaoNavigation { get; set; }
    }
}
