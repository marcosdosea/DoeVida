﻿using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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