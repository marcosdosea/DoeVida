using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoeVidaWeb.ViewModels
{
    public class ItemViewModel
    {
        public int IdItem { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int IdOrganizacao { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Status { get; set; }

    }
}