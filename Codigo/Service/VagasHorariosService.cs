 using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class VagasHorariosService : IVagasHorariosService
    {
        private readonly DoeVidaDbContext _context;
        public VagasHorariosService(DoeVidaDbContext context)
        {
            _context = context;
        }

        /// <summary>
		/// Insere uma nova Vagashorarios na base de dados
		/// </summary>
		/// <param name="vagasHorarios">dados do VagasHorarios</param>
		/// <returns>Retorna o Id da Vagashorarios inserida</returns>
        public int Insert(Vagashorarios vagasHorarios)
        {
            _context.Vagashorarios.Add(vagasHorarios);
            _context.SaveChanges();
            return vagasHorarios.IdVagasHorarios;
        }

        /// <summary>
		/// Atualiza os dados da VagasHorarios na base de dados
		/// </summary>
		/// <param name="vagasHorarios">dados da Vagashorarios</param>
        public void Edit(Vagashorarios vagasHorarios)
        {
            _context.Update(vagasHorarios);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtém todas as Vagashorarioss
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vagashorarios> GetAll()
        {
            var query = from Vagashorarios in _context.Vagashorarios
                        select Vagashorarios;
            return query;
        }

        /// <summary>
        /// Remove uma Vagashorarios da base de dados
        /// </summary>
        /// <param name="idVagashorarios">identificador da organização</param>
        public void Delete(int idVagashorarios)
        {
            var _vagasHorarios = _context.Vagashorarios.Find(idVagashorarios);
            _context.Vagashorarios.Remove(_vagasHorarios);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtér a quantidade de Vagashorarios.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            var query = (from Vagashorarios in _context.Vagashorarios
                         select Vagashorarios.IdVagasHorarios).Count();
            return query;
        }

        /// <summary>
        /// Obtém uma pagina de Vagashorarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vagashorarios> GetTakePage(int page, int take)
        {
            var query = from Vagashorarios in _context.Vagashorarios
                        select Vagashorarios;
            return query.Take(take).Skip(page * (take-1)).ToList();
        }

        /// <summary>
		/// Obtém pelo identificador da Vagashorarios
		/// </summary>
		/// <param name="idVagashorarios"></param>
		/// <returns>Retorna um Vagashorarios</returns>
        public Vagashorarios Get(int idVagashorarios)
        {
            // todo: execption?
            var _Vagashorarios = _context.Vagashorarios.Find(idVagashorarios);
            return _Vagashorarios;
        }

        /// <summary>
		/// Obter todas as Vagashorarios ordenando pelo dia da semana
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Vagashorarios> GetAllOrderByName()
        {
            var query = from Vagashorarios in _context.Vagashorarios
                        orderby Vagashorarios.DiaSemana
                        select Vagashorarios;
            return query;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
