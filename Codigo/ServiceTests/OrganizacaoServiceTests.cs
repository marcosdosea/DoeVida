using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class OrganizacaoServiceTests
    {
        private DoeVidaDbContext _context;
        private IOrganizacaoService _organizacaoService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<DoeVidaDbContext>();
            builder.UseInMemoryDatabase("doevida");
            var options = builder.Options;

            _context = new DoeVidaDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var organizacaos = new List<Organizacao>
                {
                new Organizacao
                {
                    IdOrganizacao = 1,
                    NomeOrganizacao = "UFSITA1",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cnpj = "1824873211",
                    Complemento = "Organizacao",
                    Latitude = "100",
                    Longitude = "100",
                    Logradouro = "Av. ",
                    NumeroEndereco = "0",
                    Uf = "SE",
                },
                new Organizacao
                {
                    IdOrganizacao = 2,
                    NomeOrganizacao = "UFSITA2",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cnpj = "1824873212",
                    Complemento = "Organizacao",
                    Latitude = "100",
                    Longitude = "100",
                    Logradouro = "Av. ",
                    NumeroEndereco = "0",
                    Uf = "SE",
                },
                new Organizacao
                {
                    IdOrganizacao = 3,
                    NomeOrganizacao = "UFSITA3",
                    Cep = "49500000",
                    Telefone = "79999221213",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cnpj = "1824873212",
                    Complemento = "Organizacao",
                    Latitude = "100",
                    Longitude = "100",
                    Logradouro = "Av. ",
                    NumeroEndereco = "0",
                    Uf = "SE",
                },
                };

            _context.AddRange(organizacaos);
            _context.SaveChanges();

            _organizacaoService = new OrganizacaoService(_context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Act
            _organizacaoService.Insert(new Organizacao
            {
                IdOrganizacao = 4,
                NomeOrganizacao = "UFSITA4",
                Cep = "49500000",
                Telefone = "79999221212",
                Bairro = "Centro",
                Cidade = "Itabaiana",
                Cnpj = "1824873214",
                Complemento = "Organizacao",
                Latitude = "100",
                Longitude = "100",
                Logradouro = "Av. ",
                NumeroEndereco = "0",
                Uf = "SE",
            });
            // Assert
            Assert.AreEqual(4, _organizacaoService.GetAll().Count());
            var organizacao = _organizacaoService.Get(4);
            Assert.AreEqual("1824873214", organizacao.Cnpj);
        }

        [TestMethod()]
        public void EditTest()
        {
            var organizacao = _organizacaoService.Get(3);
            organizacao.Cidade = "Aracaju";
            _organizacaoService.Edit(organizacao);
            organizacao = _organizacaoService.Get(3);
            Assert.AreEqual("Aracaju", organizacao.Cidade);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _organizacaoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _organizacaoService.GetAll().Count());
            var organizacao = _organizacaoService.Get(2);
            Assert.AreEqual(null, organizacao);
        }


        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaOrganizacao = _organizacaoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaOrganizacao, typeof(IEnumerable<Organizacao>));
            Assert.IsNotNull(listaOrganizacao);
            Assert.AreEqual(3, listaOrganizacao.Count());
            Assert.AreEqual(1, listaOrganizacao.First().IdOrganizacao);
            Assert.AreEqual("UFSITA1", listaOrganizacao.First().NomeOrganizacao);
        }

        [TestMethod()]
        public void GetTest()
        {
            var organizacao = _organizacaoService.Get(1);
            Assert.IsNotNull(organizacao);
            Assert.AreEqual("UFSITA1", organizacao.NomeOrganizacao);
            Assert.AreEqual("1824873211", organizacao.Cnpj);
        }



        [TestMethod()]
        public void GetAllOrderByNameTest()
        {
            // Act
            var listaOrganizacao = _organizacaoService.GetAllOrderByName();
            // Assert
            Assert.IsInstanceOfType(listaOrganizacao, typeof(IEnumerable<Organizacao>));
            Assert.IsNotNull(listaOrganizacao);
            Assert.AreEqual(3, listaOrganizacao.Count());
            Assert.AreEqual(1, listaOrganizacao.First().IdOrganizacao);
        }

        [TestMethod()]
        public void GetByNameContainedTest()
        {
            // Act
            var listaOrganizacao = _organizacaoService.GetByNameContained("3");
            // Assert
            Assert.IsInstanceOfType(listaOrganizacao, typeof(IEnumerable<Organizacao>));
            Assert.IsNotNull(listaOrganizacao);
            Assert.AreEqual(1, listaOrganizacao.Count());
            Assert.AreEqual(3, listaOrganizacao.First().IdOrganizacao);
        }

    }
}