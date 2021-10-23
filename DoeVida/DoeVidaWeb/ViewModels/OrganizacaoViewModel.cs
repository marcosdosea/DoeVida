using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoeVidaWeb.ViewModels
{
    public class OrganizacaoViewModel
    {   
        [Display(Name="Código")]
        [Key]
        public int IdOrganizacao { get; set; }
        
        [Required(ErrorMessage ="Campo requerido")]
        [RegularExpression(@"(?i)[^a-záéíóúàèìòùâêîôûãõç\s]", ErrorMessage =
            "Números e caracteres especiais (#, $, % ...) não são permitidos no nome.")]
        [StringLength(100, MinimumLength =5, ErrorMessage ="Nome da organização deve ter entre 5 - 100 caracteres.")]
        public string NomeOrganizacao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Cep invalido.")]
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

        [Display(Name = "Numero de Endereço")]
        [Required(ErrorMessage = "Campo requerido")]
        public string NumeroEndereco { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Cnpj { get; set; }

    }
}
