using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeVidaWeb.Mappers
{
    public class VagasHorarios : Profile
    {
        public VagasHorarios()
        {
            CreateMap<VagasHorariosViewModel, Vagashorarios>().ReverseMap();
        }
    }
}
