using System.ComponentModel.DataAnnotations;

namespace DoeVidaWeb.ViewModels
{
    public class OrganizacaoViewModel
    {
        [Display(Name = "Código")]
        [Key]
        public int IdOrganizacao { get; set; }

        [Display(Name = "Organização")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Nome da organização deve ter entre 5 - 100 caracteres.")]
        public string NomeOrganizacao { get; set; }

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

        [Display(Name = "Numero de Endereço")]
        [Required(ErrorMessage = "Campo requerido")]
        public string NumeroEndereco { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Cnpj { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "O telefone deve conter 11 digítos")]
        public string Telefone { get; set; }

    }
}
