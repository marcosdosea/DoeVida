using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IItemService
    {
        void Edit(Item item);

        int Insert(Item item);

        IQueryable<Item> GetQuery();
        Item Get(int idItem);
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetAllOrderByName();
        IEnumerable<Item> GetByNameContained(string name);
        void Delete(int idItem);
        void Validate();
    }
}
