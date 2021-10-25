using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DoadorService : IDoadorService
    {
        private readonly DoeVidaDbContext _context;
        public DoadorService(DoeVidaDbContext context)
        {
            _context = context;
        }

        /// <summary>
		/// Insere uma nova organização na base de dados
		/// </summary>
		/// <param name="pessoa">dados da organização</param>
		/// <returns>Retorna o Id da pessoa inserida</returns>
        public int Insert(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;
        }

        /// <summary>
        /// Remove uma organização da base de dados
        /// </summary>
        /// <param name="idPessoa">identificador da organização</param>
        public void Delete(int idPessoa)
        {
            var _pessoa = _context.Pessoa.Find(idPessoa);
            _context.Pessoa.Remove(_pessoa);
            _context.SaveChanges();
        }

        /// <summary>
		/// Obtém pelo identificador da organização
		/// </summary>
		/// <param name="idPessoa"></param>
		/// <returns>Retorna uma Pessoa</returns>
        public Pessoa Get(int idPessoa)
        {
            // todo: execption?
            var _pessoa = _context.Pessoa.Find(idPessoa);
            return _pessoa;
        }

        /// <summary>
		/// Atualiza os dados da organização na base de dados
		/// </summary>
		/// <param name="pessoa">dados da organização</param>
        public void Edit(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtém todas as Organizacoes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return GetQuery();
        }

        /// <summary>
		/// Obter todas as organizacoes ordenando pelo nome
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Pessoa> GetAllOrderByName()
        {
            var query = from Pessoa in _context.Pessoa
                        orderby Pessoa.Nome
                        select Pessoa;
            return query;
        }

        /// <summary>
		/// Consulta genérica aos dados da organizaçao
		/// </summary>
		/// <returns></returns>
		public IQueryable<Pessoa> GetQuery()
        {
            //IQueryable<Pessoa> listaPessoa = _context.Pessoa;
            var query = from pessoa in _context.Pessoa
                        select pessoa;
            return query;
        }
        /// <summary>
		/// Obter todas as organizacoes que contem o nome
		/// </summary>
        /// <param name="name">nome da organização</param>
		/// <returns></returns>
        public IEnumerable<Pessoa> GetByNameContained(string name)
        {
            var query = from pessoa in _context.Pessoa
                        where pessoa.Nome.Contains(name)
                        select pessoa;
            return query;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
