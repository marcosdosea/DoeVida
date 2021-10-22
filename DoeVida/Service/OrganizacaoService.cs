using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    class OrganizacaoService : IOrganizacaoService
    {
        private readonly DoeVidaDbContext _context;
        public OrganizacaoService(DoeVidaDbContext context)
        {
            _context = context;
        }

        /// <summary>
		/// Insere uma nova organização na base de dados
		/// </summary>
		/// <param name="organizacao">dados da organização</param>
		/// <returns>Retorna o Id da organizacao inserida</returns>
        public int Insert(Organizacao organizacao)
        {
            _context.Add(organizacao);
            _context.SaveChanges();
            return organizacao.IdOrganizacao;
        }

        /// <summary>
		/// Atualiza os dados da organização na base de dados
		/// </summary>
		/// <param name="organizacao">dados da organização</param>
        public void Edit(Organizacao organizacao)
        {
            _context.Update(organizacao);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove uma organização da base de dados
        /// </summary>
        /// <param name="idOrganizacao">identificador da organização</param>
        public void Delete(int idOrganizacao)
        {
            var _organizacao = _context.Organizacao.Find(idOrganizacao);
            _context.Organizacao.Remove(_organizacao);
            _context.SaveChanges();
        }

        /// <summary>
		/// Consulta genérica aos dados da organizaçao
		/// </summary>
		/// <returns></returns>
		public IQueryable<Organizacao> GetQuery()
        {
            //IQueryable<Organizacao> listaOrganizacao = _context.Organizacao;
            var query = from organizacao in _context.Organizacao
                        select organizacao;
            return query;
        }

        /// <summary>
        /// Obtém todas as Organizacoes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Organizacao> GetAll()
        {
            return GetQuery();
        }

        /// <summary>
		/// Obtém pelo identificador da organização
		/// </summary>
		/// <param name="idOrganizacao"></param>
		/// <returns>Retorna uma Organizacao</returns>
        public Organizacao Get(int idOrganizacao)
        {
            // todo: execption?
            var _organizacao = _context.Organizacao.Find(idOrganizacao);
            return _organizacao;
        }

        /// <summary>
		/// Obter todas as organizacoes ordenando pelo nome
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Organizacao> GetAllOrderByName()
        {
            var query = from Organizacao in _context.Organizacao
                        orderby Organizacao.NomeOrganizacao
                        select Organizacao;
            return query;
        }

        /// <summary>
		/// Obter todas as organizacoes que contem o nome
		/// </summary>
        /// <param name="name">nome da organização</param>
		/// <returns></returns>
        public IEnumerable<Organizacao> GetByNameContained(string name)
        {
            var query = from organizacao in _context.Organizacao
                        where organizacao.NomeOrganizacao.Contains(name)
                        select organizacao;
            return query;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}