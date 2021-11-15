using System.Collections.Generic;

namespace Core.Service
{
    public interface IAgendamentoService
    {
        void Edit(Agendamento agendamento);

        int Insert(Agendamento agendamento);
        Agendamento Get(int idAgendamento);
        IEnumerable<AgendamentoListDTO> GetAll();
        IEnumerable<AgendamentoListDTO> GetFirstTen(int page);
        IEnumerable<AgendamentoListDTO> GetAllOrderByName();
        IEnumerable<AgendamentoListDTO> GetByNameContained(string name);
        int GetCount();
        void Validate();

        // todo: GetAgendaDisponivel
    }
}
