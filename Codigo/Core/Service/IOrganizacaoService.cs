using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOrganizacaoService
    {
        void Edit(Organizacao organizacao);

        int Insert(Organizacao organizacao);

        IQueryable<Organizacao> GetQuery();
        Organizacao Get(int idOrganizacao);
        IEnumerable<Organizacao> GetAll();
        IEnumerable<Organizacao> GetAllOrderByName();
        IEnumerable<Organizacao> GetByNameContained(string name);
        void Delete(int idOrganizacao);
        void Validate();
    }
}
