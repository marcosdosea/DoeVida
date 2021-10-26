using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoeVidaWeb.ViewModels
{
    public class DoadorViewModel
    {
        public int IdPessoa { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP precisa de 8 digitos!")]
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
        [StringLength(11,MinimumLength = 8, ErrorMessage = "O cpf deve conter 11 digítos")]
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
        [StringLength(11, MinimumLength = 8, ErrorMessage = "O telefone deve conter 11 digítos")]
        public string Telefone { get; set; }

    }
}
