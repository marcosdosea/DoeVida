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
    public class AgendamentoServiceTests
    {
        private DoeVidaDbContext _context;
        private IAgendamentoService _agendamentoService;

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
            var agendamentos = new List<Agendamento>
                {
                new Agendamento
                {
                    IdAgendamento = 1,
                    Data = DateTime.Parse("2021-11-4"),
                    Descricao = "Agendamento",
                    HorarioAgendamento = TimeSpan.Parse("6:12"),
                    IdOrganizacao = 253,
                    IdPessoa = 2,
                    Status = "Agendado",
                    Tipo = "Remoto",
                },
                new Agendamento
                {
                    IdAgendamento = 2,
                    Data = DateTime.Parse("2021-11-5"),
                    Descricao = "Agendamento",
                    HorarioAgendamento = TimeSpan.Parse("6:12"),
                    IdOrganizacao = 253,
                    IdPessoa = 2,
                    Status = "Agendado",
                    Tipo = "Remoto",
                },
                new Agendamento
                {
                    IdAgendamento = 3,
                    Data = DateTime.Parse("2021-11-5"),
                    Descricao = "Agendamento",
                    HorarioAgendamento = TimeSpan.Parse("6:30"),
                    IdOrganizacao = 253,
                    IdPessoa = 3,
                    Status = "Agendado",
                    Tipo = "Remoto",
                },
                };

            _context.AddRange(agendamentos);
            _context.Add(new Pessoa() { IdPessoa = 2, Cpf = "12345678", Email = "test@test", Nome = "UserTest" });
            _context.Add(new Pessoa() { IdPessoa = 3, Cpf = "12385678", Email = "atest@test", Nome = "AUserTest" });
            _context.Add(new Organizacao() { IdOrganizacao = 253 });
            _context.SaveChanges();

            _agendamentoService = new AgendamentoService(_context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Act
            _agendamentoService.Insert(new Agendamento
            {
                IdAgendamento = 4,
                Data = DateTime.Parse("2021-11-5"),
                Descricao = "Agendamento",
                HorarioAgendamento = TimeSpan.Parse("6:12"),
                IdOrganizacao = 253,
                IdPessoa = 2,
                Status = "Agendado",
                Tipo = "Remoto",
            });
            // Assert
            Assert.AreEqual(4, _agendamentoService.GetAll().Count());
            var agendamento = _agendamentoService.Get(4);
            Assert.AreEqual(DateTime.Parse("2021-11-5"), agendamento.Data);
            Assert.AreEqual(2, agendamento.IdPessoa);
        }

        [TestMethod()]
        public void EditTest()
        {
            var agendamento = _agendamentoService.Get(3);
            agendamento.Status = "Atendido";
            _agendamentoService.Edit(agendamento);
            agendamento = _agendamentoService.Get(3);
            Assert.AreEqual("Atendido", agendamento.Status);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAgendamento = _agendamentoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAgendamento, typeof(IEnumerable<AgendamentoListDTO>));
            Assert.IsNotNull(listaAgendamento);
            Assert.AreEqual(3, listaAgendamento.Count());
            Assert.AreEqual(1, listaAgendamento.First().IdAgendamento);
            Assert.AreEqual("UserTest", listaAgendamento.First().NomePessoa);
        }

        [TestMethod()]
        public void GetTest()
        {
            var agendamento = _agendamentoService.Get(1);
            Assert.IsNotNull(agendamento);
            Assert.AreEqual(2, agendamento.IdPessoa);
            Assert.AreEqual(253, agendamento.IdOrganizacao);
        }

        [TestMethod()]
        public void GetCountTest()
        {
            var countAgendamento = _agendamentoService.GetCount();
            Assert.IsNotNull(countAgendamento);
            Assert.AreEqual(3, countAgendamento);
        }

        [TestMethod()]
        public void GetAllOrderByNameTest()
        {
            // Act
            var listaAgendamento = _agendamentoService.GetAllOrderByName();
            // Assert
            Assert.IsInstanceOfType(listaAgendamento, typeof(IEnumerable<AgendamentoListDTO>));
            Assert.IsNotNull(listaAgendamento);
            Assert.AreEqual(3, listaAgendamento.Count());
            Assert.AreEqual(3, listaAgendamento.First().IdAgendamento);
            Assert.AreEqual(3, listaAgendamento.First().IdPessoa);
        }

        [TestMethod()]
        public void GetByNameContainedTest()
        {
            // Act
            var listaAgendamento = _agendamentoService.GetByNameContained("AUser");
            // Assert
            Assert.IsInstanceOfType(listaAgendamento, typeof(IEnumerable<AgendamentoListDTO>));
            Assert.IsNotNull(listaAgendamento);
            Assert.AreEqual(1, listaAgendamento.Count());
            Assert.AreEqual(3, listaAgendamento.First().IdAgendamento);
            Assert.AreEqual(3, listaAgendamento.First().IdPessoa);
        }
    }
}