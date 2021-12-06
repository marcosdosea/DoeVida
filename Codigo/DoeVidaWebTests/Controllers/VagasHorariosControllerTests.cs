using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.Mappers;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DoeVidaWeb.Controllers.Tests
{
    [TestClass()]
    public class VagasHorariosControllerTests
    {
        private static VagasHorariosController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IVagasHorariosService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new VagasHorariosProfile())).CreateMapper();

            mockService.Setup(service => service.GetTakePage(0,10))
                .Returns(GetTestVagashorarios());

            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetVagashorarios());
            mockService.Setup(service => service.Edit(It.IsAny<Vagashorarios>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Vagashorarios>()))
                .Verifiable();
            mockService.Setup(service => service.Delete(1))
                .Verifiable();

            controller = new VagasHorariosController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<VagasHorariosViewModel>));
            List<VagasHorariosViewModel> list = (List<VagasHorariosViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VagasHorariosViewModel));
            VagasHorariosViewModel vagasHorariosViewModel = (VagasHorariosViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Segunda-feira", vagasHorariosViewModel.DiaSemana);

        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewVagashorarios());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("CNPJ", "Campo requerido");

            // Act
            var result = controller.Create(GetNewVagashorarios());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VagasHorariosViewModel));
            VagasHorariosViewModel vagasHorariosViewModel = (VagasHorariosViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Segunda-feira", vagasHorariosViewModel.DiaSemana);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetVagasHorariosViewModel().IdVagasHorarios, GetTargetVagasHorariosViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VagasHorariosViewModel));
            VagasHorariosViewModel vagasHorariosViewModel = (VagasHorariosViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Segunda-feira", vagasHorariosViewModel.DiaSemana);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetVagasHorariosViewModel().IdVagasHorarios, GetTargetVagasHorariosViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static IEnumerable<Vagashorarios> GetTestVagashorarios()
        {
            return new List<Vagashorarios>
            {
                new Vagashorarios
                {
                IdVagasHorarios = 1,
                DiaSemana = "Segunda-feira",
                HoraInicio = new TimeSpan(5, 0, 0),
                HoraFinal = new TimeSpan(6, 0, 0),
                NumeroVagas = 10,
                IdOrganizacao = 1,
                },
                new Vagashorarios
                {
                IdVagasHorarios = 2,
                DiaSemana = "Segunda-feira",
                HoraInicio = new TimeSpan(5, 0, 0),
                HoraFinal = new TimeSpan(6, 0, 0),
                NumeroVagas = 10,
                IdOrganizacao = 1,
                },
                new Vagashorarios
                {
                IdVagasHorarios = 3,
                DiaSemana = "Segunda-feira",
                HoraInicio = new TimeSpan(5, 0, 0),
                HoraFinal = new TimeSpan(6, 0, 0),
                NumeroVagas = 10,
                IdOrganizacao = 1,
                }

        };
        }

        private static VagasHorariosViewModel GetNewVagashorarios()
        {
                return new VagasHorariosViewModel
                {
                    IdVagasHorarios = 1,
                    DiaSemana = "Segunda-feira",
                    HoraInicio = new TimeSpan(5, 0, 0),
                    HoraFinal = new TimeSpan(6, 0, 0),
                    NumeroVagas = 10,
                    IdOrganizacao = 1,
                };

        }
        private static Vagashorarios GetTargetVagashorarios()
        {
            return new Vagashorarios
            {
                IdVagasHorarios = 1,
                DiaSemana = "Segunda-feira",
                HoraInicio = new TimeSpan(5, 0, 0),
                HoraFinal = new TimeSpan(6, 0, 0),
                NumeroVagas = 10,
                IdOrganizacao = 1,
            };
        }
        private static VagasHorariosViewModel GetTargetVagasHorariosViewModel()
        {
            return new VagasHorariosViewModel
            {
                IdVagasHorarios = 1,
                DiaSemana = "Segunda-feira",
                HoraInicio = new TimeSpan(5, 0, 0),
                HoraFinal = new TimeSpan(6, 0, 0),
                NumeroVagas = 10,
                IdOrganizacao = 1,
            };
        }

    }
}