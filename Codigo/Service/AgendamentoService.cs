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
            var query = from A in _context.Agendamento
                        select new AgendamentoListDTO
                        {
                            IdAgendamento = A.IdAgendamento,
                            Data = A.Data,
                            Tipo = A.Tipo,
                            Status = A.Status,
                            HorarioAgendamento = A.HorarioAgendamento,
                            Descricao = A.Descricao,
                            IdPessoa = A.IdPessoa,
                            IdOrganizacao = A.IdOrganizacao,
                            NomePessoa = A.IdPessoaNavigation.Nome
                        };
            return query;
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
            var query = from A in _context.Agendamento
                        orderby A.IdPessoaNavigation.Nome
                        select A;
            return query;
        }

        /// <summary>
		/// Obter todos os agendamentos que contem o nome do Doador
		/// </summary>
        /// <param name="name">nome do doador</param>
		/// <returns></returns>
        public IEnumerable<Agendamento> GetByNameContained(string name)
        {
            var query = from A in _context.Agendamento
                        where A.IdPessoaNavigation.Nome.Contains(name)
                        select A;
            return query;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
