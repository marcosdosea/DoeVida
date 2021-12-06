using System;
using System.ComponentModel.DataAnnotations;

namespace DoeVidaWeb.ViewModels
{
    public class VagasHorariosViewModel
    {
        [Display(Name = "Código")]
        [Key]
        public int IdVagasHorarios { get; set; }

        public string DiaSemana { get; set; }

        [Display(Name = "Horário inicio")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? HoraInicio { get; set; }
        [Display(Name = "Horário fim")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? HoraFinal { get; set; }
        public int? NumeroVagas { get; set; }
        public int IdOrganizacao { get; set; }
    }
}
