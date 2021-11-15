using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

namespace DoeVidaWeb.Mappers
{
    public class OrganizacaoProfile : Profile
    {
        public OrganizacaoProfile()
        {
            CreateMap<OrganizacaoViewModel, Organizacao>().ReverseMap();
        }
    }
}
