using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.Mappers;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DoeVidaWeb.Controllers.Tests
{
    [TestClass()]
    public class OrganizacaoControllerTests
    {
        private static OrganizacaoController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IOrganizacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new OrganizacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestOrganizacao());

            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetOrganizacao());
            mockService.Setup(service => service.Edit(It.IsAny<Organizacao>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Organizacao>()))
                .Verifiable();

            controller = new OrganizacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<OrganizacaoViewModel>));
            List<OrganizacaoViewModel> list = (List<OrganizacaoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrganizacaoViewModel));
            OrganizacaoViewModel organizacaoViewModel = (OrganizacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("UFSITA", organizacaoViewModel.NomeOrganizacao);
            Assert.AreEqual("1824873212", organizacaoViewModel.Cnpj);

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
            var result = controller.Create(GetNewOrganizacao());

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
            var result = controller.Create(GetNewOrganizacao());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrganizacaoViewModel));
            OrganizacaoViewModel organizacaoViewModel = (OrganizacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("UFSITA", organizacaoViewModel.NomeOrganizacao);
            Assert.AreEqual("1824873212", organizacaoViewModel.Cnpj);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetOrganizacaoViewModel().IdOrganizacao, GetTargetOrganizacaoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrganizacaoViewModel));
            OrganizacaoViewModel organizacaoViewModel = (OrganizacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("UFSITA", organizacaoViewModel.NomeOrganizacao);
            Assert.AreEqual("1824873212", organizacaoViewModel.Cnpj);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetOrganizacaoViewModel().IdOrganizacao, GetTargetOrganizacaoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static IEnumerable<Organizacao> GetTestOrganizacao()
        {
            return new List<Organizacao>
            {
                new Organizacao
                {
                    IdOrganizacao = 1,
                    NomeOrganizacao = "UFSITA",
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
                    IdOrganizacao = 1,
                    NomeOrganizacao = "UFSITA",
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
                    IdOrganizacao = 1,
                    NomeOrganizacao = "UFSITA",
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

            };
        }

        private static OrganizacaoViewModel GetNewOrganizacao()
        {
            return new OrganizacaoViewModel
            {
                IdOrganizacao = 1,
                NomeOrganizacao = "UFSITA",
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
            };

        }
        private static Organizacao GetTargetOrganizacao()
        {
            return new Organizacao
            {
                IdOrganizacao = 1,
                NomeOrganizacao = "UFSITA",
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
            };
        }
        private static OrganizacaoViewModel GetTargetOrganizacaoViewModel()
        {
            return new OrganizacaoViewModel
            {
                IdOrganizacao = 1,
                NomeOrganizacao = "UFSITA",
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
            };
        }

    }
}