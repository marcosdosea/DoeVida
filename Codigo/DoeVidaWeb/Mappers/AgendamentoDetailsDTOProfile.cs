using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

namespace DoeVidaWeb.Mappers
{
    public class AgendamentoDetailsDTOProfile : Profile
    {
        public AgendamentoDetailsDTOProfile()
        {
            CreateMap<AgendamentoDetailsDTOViewModel, AgendamentoDetailsDTO>().ReverseMap();
        }
    }
}
