﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOrganizacaoService
    {
        void Edit(Organizacao organizacao);

        int Insert(Organizacao organizacao);

        Organizacao Get(int idOrganizacao);
        IEnumerable<Organizacao> GetAll();
        void Delete(int idOrganizacao);
        void Validate();
    }
}
