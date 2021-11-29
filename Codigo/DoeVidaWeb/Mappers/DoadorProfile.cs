using AutoMapper;
using Core;
using DoeVidaWeb.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeVidaWeb.Mappers
{
    public class DoadorProfile : Profile
    {
        public DoadorProfile()
        {
            CreateMap<DoadorViewModel, Pessoa>()
                .ForSourceMember( x => x.Password, y => y.DoNotValidate())
                .ReverseMap();
        }
    }
}
