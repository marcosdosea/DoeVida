using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public interface IOrganizacaoService
    {
        void Edit(Organizacao organizacao);

        int Insert(Organizacao organizacao);

        Organizacao Get(int idOrganizacao);
        IEnumerable<Organizacao> GetAll();
        IEnumerable<Organizacao> GetAllOrderByName();
        IEnumerable<Organizacao> GetByNameContained(string name);
        void Delete(int idOrganizacao);
        void Validate();
    }
}
