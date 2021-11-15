using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

namespace DoeVidaWeb.Mappers
{
    public class AgendamentoListDTOProfile : Profile
    {
        public AgendamentoListDTOProfile()
        {
            CreateMap<AgendamentoListDTOViewModel, AgendamentoListDTO>().ReverseMap();
        }
    }
}
