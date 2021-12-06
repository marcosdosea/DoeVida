using System.Collections.Generic;

namespace Core.Service
{
    public interface IVagasHorariosService
    {
        void Edit(Vagashorarios Vagashorarios);

        int Insert(Vagashorarios Vagashorarios);
        Vagashorarios Get(int idVagashorarios);
        IEnumerable<Vagashorarios> GetAll();
        IEnumerable<Vagashorarios> GetTakePage(int page, int take);
        IEnumerable<Vagashorarios> GetAllOrderByName();
        int GetCount();
        void Validate();
        void Delete(int id);

        // todo: GetAgendaDisponivel
    }
}
