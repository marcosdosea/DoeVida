using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAgendamentoService
    {
        void Edit(Agendamento agendamento);

        int Insert(Agendamento agendamento);

        IQueryable<Agendamento> GetQuery();
        Agendamento Get(int idAgendamento);
        IEnumerable<Agendamento> GetAll();
        IEnumerable<Agendamento> GetAllOrderByName();
        IEnumerable<Agendamento> GetByNameContained(string name);
        void Validate();

        // todo: GetAgendaDisponivel
    }
}
