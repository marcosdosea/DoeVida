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
    public class DoadorServiceTests
    {

        private DoeVidaDbContext _context;
        private IDoadorService _doadorService;

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
            var pessoas = new List<Pessoa>
            {
                new Pessoa
                {
                    IdPessoa = 1,
                    Nome = "Daniel Gomes",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cpf = "1824873211",
                    Complemento = "Organizacao",
                    Latitude = "100",
                    Longitude = "100",
                    Logradouro = "Av. ",
                    NumeroEndereco = "0",
                    Uf = "SE",
                    DataNascimento = DateTime.Parse("2021-11-4"),
                    Email  = "teste@email.com",
                    Status = "ATIVO",
                    Tipo = "DOADOR"
                },
                 new Pessoa
                {
                    IdPessoa = 2,
                    Nome = "Diego Gomes",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cpf = "1824873212",
                    Complemento = "Pessoa",
                    Latitude = "100",
                    Longitude = "100",
                    Logradouro = "Av. ",
                    NumeroEndereco = "0",
                    Uf = "SE",
                    DataNascimento = DateTime.Parse("2021-11-4"),
                    Email  = "teste2@email.com",
                    Status = "ATIVO",
                    Tipo = "DOADOR"
                },
                  new Pessoa
                {
                    IdPessoa = 3,
                    Nome = "Rodrigo Gomes",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cpf = "1824873213",
                    Complemento = "Pessoa",
                    Latitude = "100",
                    Longitude = "100",
                    Logradouro = "Av. ",
                    NumeroEndereco = "0",
                    Uf = "SE",
                    DataNascimento = DateTime.Parse("2021-11-4"),
                    Email  = "teste3@email.com",
                    Status = "ATIVO",
                    Tipo = "DOADOR"
                },

            };

            _context.AddRange(pessoas);
            _context.SaveChanges();

            _doadorService = new DoadorService(_context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Act
            _doadorService.Insert(new Pessoa
            {
                IdPessoa = 5,
                Nome = "Daniel Gomes",
                Cep = "49500000",
                Telefone = "79999221212",
                Bairro = "Centro",
                Cidade = "Itabaiana",
                Cpf = "1824873214",
                Complemento = "Pessoa",
                Latitude = "100",
                Longitude = "100",
                Logradouro = "Av. ",
                NumeroEndereco = "0",
                Uf = "SE",
                DataNascimento = DateTime.Parse("2021-11-4"),
                Email = "teste@email.com",
                Status = "ATIVO",
                Tipo = "DOADOR"
            });
            // Assert
            Assert.AreEqual(4, _doadorService.GetAll().Count());
            var doador = _doadorService.Get(5);
            Assert.AreEqual("1824873214", doador.Cpf);
        }
        
        [TestMethod()]
        public void InsertTestInvalidUser()
        {
            // Act
            _doadorService.Insert(new Pessoa
            {
                IdPessoa = 5,
                Nome = "Daniel Gomes",
                Cep = "49500000",
                Telefone = "79999221212",
                Bairro = "Centro",
                Cidade = "Itabaiana",
                Cpf = "1824873214",
                Complemento = "Pessoa",
                Latitude = "100",
                Longitude = "100",
                Logradouro = "Av. ",
                NumeroEndereco = "0",
                Uf = "SE",
                DataNascimento = DateTime.Parse("2021-11-4"),
                Email = "teste@email.com",
                Status = "ATIVO",
                Tipo = "DOADOR"
            });
            // Assert
            Assert.AreEqual(4, _doadorService.GetAll().Count());
            var doador = _doadorService.Get(5);
            Assert.AreEqual("1824873214", doador.Cpf);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _doadorService.Delete(2);
            // Assert
            Assert.AreEqual(2, _doadorService.GetAll().Count());
            var doador = _doadorService.Get(2);
            Assert.AreEqual(null, doador);
        }

        [TestMethod()]
        public void GetTest()
        {
            var doador = _doadorService.Get(1);
            Assert.IsNotNull(doador);
            Assert.AreEqual("Daniel Gomes", doador.Nome);
            Assert.AreEqual("1824873211", doador.Cpf);
        }

        [TestMethod()]
        public void EditTest()
        {
            var doador = _doadorService.Get(3);
            doador.Cidade = "Aracaju";
            _doadorService.Edit(doador);
            doador = _doadorService.Get(3);
            Assert.AreEqual("Aracaju", doador.Cidade);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listDoador = _doadorService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listDoador, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listDoador);
            Assert.AreEqual(3, listDoador.Count());
            Assert.AreEqual(1, listDoador.First().IdPessoa);
            Assert.AreEqual("Daniel Gomes", listDoador.First().Nome);
        }

        [TestMethod()]
        public void GetAllOrderByNameTest()
        {
            // Act
            var listDoador = _doadorService.GetAllOrderByName();
            // Assert
            Assert.IsInstanceOfType(listDoador, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listDoador);
            Assert.AreEqual(3, listDoador.Count());
            Assert.AreEqual(1, listDoador.First().IdPessoa);
        }

        [TestMethod()]
        public void GetByNameContainedTest()
        {
            // Act
            var listDoador = _doadorService.GetByNameContained("Daniel");
            // Assert
            Assert.IsInstanceOfType(listDoador, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listDoador);
            Assert.AreEqual(1, listDoador.Count());
            Assert.AreEqual(1, listDoador.First().IdPessoa);
        }

    }
}
