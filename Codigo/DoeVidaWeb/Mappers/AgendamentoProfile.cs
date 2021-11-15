using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

namespace DoeVidaWeb.Mappers
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<AgendamentoViewModel, Agendamento>().ReverseMap();
        }
    }
}
