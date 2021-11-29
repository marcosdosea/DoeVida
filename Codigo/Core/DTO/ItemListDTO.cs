using System;
namespace Core
{
    public class ItemListDTO
    {
        public string NomeOrganizacao{get ; set; }
        public int IdItem { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int IdOrganizacao { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; }
    }
}
