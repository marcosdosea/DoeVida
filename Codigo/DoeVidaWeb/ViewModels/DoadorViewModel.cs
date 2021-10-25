using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoeVidaWeb.ViewModels
{
    public class DoadorViewModel
    {   
        [Display(Name="Código")]
        [Key]
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
        [Required(ErrorMessage = "Campo requerido")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(11,MinimumLength = 8, ErrorMessage = "O cpf deve conter 11 digítos")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "O telefone deve conter 11 digítos")]
        public string Telefone { get; set; }
        public int IdPessoa1 { get; set; }

    }
}
