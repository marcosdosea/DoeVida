using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoeVidaWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core.Service;
using AutoMapper;
using DoeVidaWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using DoeVidaWeb.ViewModels;

namespace DoeVidaWeb.Controllers.Tests
{
    [TestClass()]
    public class AgendamentoControllerTests
    {
        private static AgendamentoController controller;

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            var _controller = InitializateWithMapperListDTO();
            // Act
            var result = _controller.Index(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AgendamentoListDTOViewModel>));
            List<AgendamentoListDTOViewModel> list = (List<AgendamentoListDTOViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, list.Count);
        }


        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Arrange
            var _controller = InitializateWithMapperDefault();

            // Act
            var result = _controller.Create(GetNewAgendamento());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Invalid()
        {
            // Arrange
            var _controller = InitializateWithMapperDefault();
            _controller.ModelState.AddModelError("IdPessoa", "Campo requerido");

            // Act
            var result = _controller.Create(GetNewAgendamento());

            // Assert
            Assert.AreEqual(1, _controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest()
        {   
            // Arrange
            var _controller = InitializateWithMapperDefault();
            var edited = GetNewAgendamento();
            edited.Status = "Atendido";
            // Act
			var result = _controller.Edit(1, edited);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AgendamentoViewModel));
			AgendamentoViewModel agendamentoViewModel = (AgendamentoViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Atendido", agendamentoViewModel.Status);
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        private static IEnumerable<AgendamentoListDTO> GetTestAgendamento()
        {
            return new List<AgendamentoListDTO>
            {
                new AgendamentoListDTO
                {
                    IdAgendamento = 1,
                    Data = DateTime.Parse("2021-11-4"),
                    Descricao = "Agendamento",
                    HorarioAgendamento = TimeSpan.Parse("6:12"),
                    IdOrganizacao = 253,
                    IdPessoa = 2,
                    NomePessoa = "Idyl Ícaro dos Santos",
                    Status = "Agendado",
                    Tipo = "Remoto"
                },
                new AgendamentoListDTO
                {
                    IdAgendamento = 2,
                    Data = DateTime.Parse("2021-11-4"),
                    Descricao = "Agendamento",
                    HorarioAgendamento = TimeSpan.Parse("6:12"),
                    IdOrganizacao = 253,
                    IdPessoa = 4,
                    NomePessoa = "Idyl dos Santos",
                    Status = "Agendado",
                    Tipo = "Remoto"
                },
                new AgendamentoListDTO
                {
                    IdAgendamento = 3,
                    Data = DateTime.Parse("2021-11-4"),
                    Descricao = "Agendamento",
                    HorarioAgendamento = TimeSpan.Parse("6:12"),
                    IdOrganizacao = 253,
                    IdPessoa = 3,
                    NomePessoa = "Ícaro dos Santos",
                    Status = "Agendado",
                    Tipo = "Remoto"
                },

            };
        }
        private static AgendamentoViewModel GetNewAgendamento()
        {
            return new AgendamentoViewModel
            {
                IdAgendamento = 1,
                Data = DateTime.Parse("2021-11-4"),
                Descricao = "Agendamento",
                HorarioAgendamento = TimeSpan.Parse("6:12"),
                IdOrganizacao = 253,
                IdPessoa = 2,
                Status = "Agendado",
                Tipo = "Remoto",
            };

        }
        private static Agendamento GetTargetAgendamento()
        {
            return new Agendamento
            {
                IdAgendamento = 1,
                Data = DateTime.Parse("2021-11-4"),
                Descricao = "Agendamento",
                HorarioAgendamento = TimeSpan.Parse("6:12"),
                IdOrganizacao = 253,
                IdPessoa = 2,
                Status = "Agendado",
                Tipo = "Remoto",
            };
        }

        private AgendamentoController InitializateWithMapperListDTO()
        {
            var mockService = new Mock<IAgendamentoService>();
            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AgendamentoListDTOProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAgendamento());

            return new AgendamentoController(mockService.Object, mapper);
        }
        private AgendamentoController InitializateWithMapperDefault()
        {
            var mockService = new Mock<IAgendamentoService>();
            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AgendamentoProfile())).CreateMapper();

            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAgendamento());
            mockService.Setup(service => service.Edit(It.IsAny<Agendamento>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Agendamento>()))
                .Verifiable();

            return new AgendamentoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void EditStatusTest()
        {   
            // Arrange
            var _controller = InitializateWithMapperDefault();

            // Act
            var result = _controller.EditStatus(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(String));
            Assert.AreEqual("Atendido com sucesso!", result);
        }
    }
}