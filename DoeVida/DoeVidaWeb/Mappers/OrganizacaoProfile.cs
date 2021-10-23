using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
