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
    public class VagasHorariosServiceTests
    {
        private DoeVidaDbContext _context;
        private IVagasHorariosService _vagasHorariosService;
            
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
            var vagasHorarios = new List<Vagashorarios>
                {
                new Vagashorarios
                {   IdVagasHorarios = 1,
                    DiaSemana = "Segunda-feira",
                    HoraInicio = new TimeSpan(5, 0, 0),
                    HoraFinal = new TimeSpan(6, 0, 0),
                    NumeroVagas = 10,
                    IdOrganizacao = 1,
                },
                new Vagashorarios
                {   IdVagasHorarios = 2,
                    DiaSemana = "Quarta-feira",
                    HoraInicio = new TimeSpan(5, 0, 0),
                    HoraFinal = new TimeSpan(6, 0, 0),
                    NumeroVagas = 10,
                    IdOrganizacao = 1,
                },
                new Vagashorarios
                {   IdVagasHorarios = 3,
                    DiaSemana = "Sexta-feira",
                    HoraInicio = new TimeSpan(5, 0, 0),
                    HoraFinal = new TimeSpan(6, 0, 0),
                    NumeroVagas = 10,
                    IdOrganizacao = 1,
                },
                };

            _context.AddRange(vagasHorarios);
            _context.Add(new Organizacao
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
            });
            _context.SaveChanges();

            _vagasHorariosService = new VagasHorariosService(_context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Act
            _vagasHorariosService.Insert(new Vagashorarios
            {
                IdVagasHorarios = 4,
                DiaSemana = "Quinta-feira",
                HoraInicio = new TimeSpan(5, 0, 0),
                HoraFinal = new TimeSpan(6, 0, 0),
                NumeroVagas = 10,
                IdOrganizacao = 1,
            });
            // Assert
            Assert.AreEqual(4, _vagasHorariosService.GetAll().Count());
            var vagashorarios = _vagasHorariosService.Get(4);
            Assert.AreEqual("Quinta-feira", vagashorarios.DiaSemana);
        }

        [TestMethod()]
        public void EditTest()
        {
            var vagashorarios = _vagasHorariosService.Get(3);
            vagashorarios.DiaSemana = "Domingo";
            _vagasHorariosService.Edit(vagashorarios);
            vagashorarios = _vagasHorariosService.Get(3);
            Assert.AreEqual("Domingo", vagashorarios.DiaSemana);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _vagasHorariosService.Delete(2);
            // Assert
            Assert.AreEqual(2, _vagasHorariosService.GetAll().Count());
            var vagasHorarios = _vagasHorariosService.Get(2);
            Assert.AreEqual(null, vagasHorarios);
        }

        [TestMethod()]
        public void GetFirstTenTest()
        {
            // Act
            var listaVagasHorarios = _vagasHorariosService.GetTakePage(0,10);
            // Assert
            Assert.IsInstanceOfType(listaVagasHorarios, typeof(IEnumerable<Vagashorarios>));
            Assert.IsNotNull(listaVagasHorarios);
            Assert.AreEqual(listaVagasHorarios.Count() <= 10, true);
            Assert.AreEqual(1, listaVagasHorarios.First().IdOrganizacao);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaVagasHorarios = _vagasHorariosService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaVagasHorarios, typeof(IEnumerable<Vagashorarios>));
            Assert.IsNotNull(listaVagasHorarios);
            Assert.AreEqual(3, listaVagasHorarios.Count());
            Assert.AreEqual(1, listaVagasHorarios.First().IdOrganizacao);
            Assert.AreEqual("Segunda-feira", listaVagasHorarios.First().DiaSemana);
        }

        [TestMethod()]
        public void GetTest()
        {
            var vagasHorarios = _vagasHorariosService.Get(1);
            Assert.IsNotNull(vagasHorarios);
            Assert.AreEqual("Segunda-feira", vagasHorarios.DiaSemana);
        }

        [TestMethod()]
        public void GetCountTest()
        {
            var countvagasHorarios = _vagasHorariosService.GetCount();
            Assert.IsNotNull(countvagasHorarios);
            Assert.AreEqual(3, countvagasHorarios);
        }
    }
}