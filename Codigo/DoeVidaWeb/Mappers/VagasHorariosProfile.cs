using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

namespace DoeVidaWeb.Mappers
{
    public class VagasHorariosProfile : Profile
    {
        public VagasHorariosProfile()
        {
            CreateMap<VagasHorariosViewModel, Vagashorarios>().ReverseMap();
        }
    }
}
