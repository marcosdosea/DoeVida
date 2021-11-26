using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public class ItemService : IItemService
    {
        private readonly DoeVidaDbContext _context;

        public ItemService(DoeVidaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insere um novo item na base de dados
        /// </summary>
        /// <param name="Item">dados do Item</param>
        /// <returns>Retorna o Id do Item inserido</returns>
        public int Insert(Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
            return item.IdItem;
        }

        /// <summary>
        /// Remove um Item da Base de dados
        /// </summary>
        /// <param name="idItem">identificador do Item </param>
        public void Delete(int idItem)
        {
            var _item = _context.Item.Find(idItem);
            _context.Item.Remove(_item);
            _context.SaveChanges();
        }

        /// <summary>
		/// Obtém pelo identificador do Item
		/// </summary>
		/// <param name="idItem"></param>
		/// <returns>Retorna um Item</returns>
        public Item Get(int idItem)
        {
            // todo: execption?
            var _item = _context.Item.Find(idItem);
            return _item;
        }

        /// <summary>
		/// Atualiza os dados do Item na Base de Dados
		/// </summary>
		/// <param name="item">dados do item</param>
        public void Edit(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
        public IEnumerable<ItemListDTO> GetDTO(int id) 
        {
            var item = from Item in _context.Item
                       where Item.IdItem.Equals(id)
                        select new ItemListDTO
                        {
                            IdItem = Item.IdItem,
                            IdOrganizacao = Item.IdOrganizacao,
                            Nome = Item.Nome,
                            Quantidade = Item.Quantidade,
                            Status = Item.Status,
                            Tipo = Item.Tipo,
                            NomeOrganizacao = Item.IdOrganizacaoNavigation.NomeOrganizacao
                        };
            return item;
        }
        /// <summary>
        /// Obtém todas os Iten
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemListDTO> GetAll()
        {
            var query = from Item in _context.Item
                        select new ItemListDTO
                        {
                            IdItem = Item.IdItem,
                            IdOrganizacao = Item.IdOrganizacao,
                            Nome = Item.Nome,
                            Quantidade = Item.Quantidade,
                            Status = Item.Status,
                            Tipo = Item.Tipo,
                            NomeOrganizacao = Item.IdOrganizacaoNavigation.NomeOrganizacao
                        };
            return query;
        }

        /// <summary>
		/// Obter todas os Iten ordenando pelo nome
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Item> GetAllOrderByName()
        {
            var query = from Item in _context.Item
                        orderby Item.Nome
                        select Item;
            return query;
        }

        /// <summary>
		/// Consulta genérica aos dados do Item
		/// </summary>
		/// <returns></returns>
		public IQueryable<Item> GetQuery()
        {
            //IQueryable<Item> listaItem = _context.Item;
            var query = from Item in _context.Item
                        select Item;
            return query;
        }
        /// <summary>
		/// Obter todas os iten que contem o nome
		/// </summary>
        /// <param name="name">nome do item</param>
		/// <returns></returns>
        public IEnumerable<Item> GetByNameContained(string name)
        {
            var query = from Item in _context.Item
                        where Item.Nome.Contains(name)
                        select Item;
            return query;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

    }

}