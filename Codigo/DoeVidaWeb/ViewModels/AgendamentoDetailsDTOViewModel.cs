using System;
using System.ComponentModel.DataAnnotations;

namespace DoeVidaWeb.ViewModels
{
    public class AgendamentoDetailsDTOViewModel
    {
        [Display(Name = "Código")]
        [Key]
        public int IdAgendamento { get; set; }

        [Display(Name = "Data do Atendimento"),
        Required(ErrorMessage = "Campo requerido"),
        DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Campo requerido"),
        DataType(DataType.Time),
        Display(Name = "Horário"),
        DisplayFormat(DataFormatString = @"{0:hh\:mm\:ss}", ApplyFormatInEditMode = true),
        ]
        // Range(typeof(TimeSpan), "08:00", "15:00")
        public TimeSpan HorarioAgendamento { get; set; }

        [Required(ErrorMessage = "Campo requerido"),
        StringLength(500, ErrorMessage = "Descrição excedeu 500 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int IdOrganizacao { get; set; }

        [Display(Name = "Nome")]
        public string NomePessoa { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
