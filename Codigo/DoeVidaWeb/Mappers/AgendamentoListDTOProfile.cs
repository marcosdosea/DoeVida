using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
