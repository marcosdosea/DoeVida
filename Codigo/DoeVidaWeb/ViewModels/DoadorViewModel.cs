using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoeVidaWeb.ViewModels
{
    public class DoadorViewModel
    {
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Uf { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string NumeroEndereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string IdUser { get; set; }

    }
}
