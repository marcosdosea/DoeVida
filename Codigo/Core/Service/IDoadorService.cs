using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public interface IDoadorService
    {
        int Insert(Pessoa pessoa);
        void Edit(Pessoa pessoa);
        IQueryable<Pessoa> GetQuery();
        Pessoa Get(int idPessoa);
        IEnumerable<Pessoa> GetAll();
        IEnumerable<Pessoa> GetAllOrderByName();
        IEnumerable<Pessoa> GetByNameContained(string name);
        void Delete(int idPessoa);

        void Validate();
    }
}