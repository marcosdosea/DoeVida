using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Core;

namespace Service
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly DoeVidaDbContext _context;
        public AgendamentoService(DoeVidaDbContext context)
        {
            _context = context;
        }

        /// <summary>
		/// Insere um novo agendamento na base de dados
		/// </summary>
		/// <param name="agendamento">dados do agendamento</param>
		/// <returns>Retorna o Id da agendamento inserida</returns>
        public int Insert(Agendamento agendamento)
        {
            _context.Agendamento.Add(agendamento);
            _context.SaveChanges();
            return agendamento.IdAgendamento;
        }

        /// <summary>
		/// Atualiza os dados do agendamento na base de dados
		/// </summary>
		/// <param name="agendamento">dados do agendamento</param>
        public void Edit(Agendamento agendamento)
        {
            _context.Update(agendamento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtém todos os Agendamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AgendamentoListDTO> GetAll()
        {
            var query = from Agendamento in _context.Agendamento
                        select new AgendamentoListDTO
                        {
                            IdAgendamento = Agendamento.IdAgendamento,
                            Data = Agendamento.Data,
                            Tipo = Agendamento.Tipo,
                            Status = Agendamento.Status,
                            HorarioAgendamento = Agendamento.HorarioAgendamento,
                            Descricao = Agendamento.Descricao,
                            IdPessoa = Agendamento.IdPessoa,
                            IdOrganizacao = Agendamento.IdOrganizacao,
                            NomePessoa = Agendamento.IdPessoaNavigation.Nome
                        };
            return query;
        }

        /// <summary>
        /// Obtér a quantidade de agendamentos.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            var query = (from Agendamento in _context.Agendamento
                        select Agendamento.IdAgendamento).Count(); 
            return query;
        }

        /// <summary>
        /// Obtém 10 os Agendamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AgendamentoListDTO> GetFirstTen(int page)
		{
			var query = from Agendamento in _context.Agendamento
                        select new AgendamentoListDTO
                        {
                            IdAgendamento = Agendamento.IdAgendamento,
                            Data = Agendamento.Data,
                            Tipo = Agendamento.Tipo,
                            Status = Agendamento.Status,
                            HorarioAgendamento = Agendamento.HorarioAgendamento,
                            Descricao = Agendamento.Descricao,
                            IdPessoa = Agendamento.IdPessoa,
                            IdOrganizacao = Agendamento.IdOrganizacao,
                            NomePessoa = Agendamento.IdPessoaNavigation.Nome
                        };
            return query.Take(10).Skip(page).ToList();
		}

        /// <summary>
		/// Obtém pelo identificador do agendamento
		/// </summary>
		/// <param name="idAgendamento"></param>
		/// <returns>Retorna um Agendamento</returns>
        public Agendamento Get(int idAgendamento)
        {
            // todo: execption?
            var _agendamento = _context.Agendamento.Find(idAgendamento);
            return _agendamento;
        }

        /// <summary>
		/// Obter todos os agendamentos ordenando pelo nome do doador
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Agendamento> GetAllOrderByName()
        {
            var query = from Agendamento in _context.Agendamento
                        orderby Agendamento.IdPessoaNavigation.Nome
                        select Agendamento;
            return query;
        }

        /// <summary>
		/// Obter todos os agendamentos que contem o nome do Doador
		/// </summary>
        /// <param name="name">nome do doador</param>
		/// <returns></returns>
        public IEnumerable<Agendamento> GetByNameContained(string name)
        {
            var query = from Agendamento in _context.Agendamento
                        where Agendamento.IdPessoaNavigation.Nome.Contains(name)
                        select Agendamento;
            return query;
        }

                public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
