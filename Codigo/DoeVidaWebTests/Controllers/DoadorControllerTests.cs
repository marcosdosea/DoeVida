using Moq;
using Core;
using System;
using AutoMapper;
using Core.Service;
using DoeVidaWeb.Mappers;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoeVidaWeb.Controllers.Tests
{
    [TestClass()]
    public class DoadorControllerTests
    {

        private static DoadorController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IDoadorService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new DoadorProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestDoador());

            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetDoador());

            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Pessoa>()))
                .Verifiable();

            controller = new DoadorController(mockService.Object, mapper, null, null);
        }


        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DoadorViewModel>));
            List<DoadorViewModel> lista = (List<DoadorViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Pessoa));
            Assert.AreEqual("Daniel Gomes", result.Nome);
            Assert.AreEqual("1824873212", result.Cpf);
        }


        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.CreateAsync(GetNewDoador());

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
            controller.ModelState.AddModelError("CPF", "Campo requerido");

            // Act
            var result = controller.CreateAsync(GetNewDoador());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DoadorViewModel));
            DoadorViewModel doadorViewModel = (DoadorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Daniel Gomes", doadorViewModel.Nome);
            Assert.AreEqual("1824873212", doadorViewModel.Cpf);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetDoadorViewModel().IdPessoa, GetTargetDoadorViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DoadorViewModel));
            DoadorViewModel doadorViewModel = (DoadorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Daniel Gomes", doadorViewModel.Nome);
            Assert.AreEqual("1824873212", doadorViewModel.Cpf);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetDoadorViewModel().IdPessoa, GetTargetDoadorViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static DoadorViewModel GetNewDoador()
        {
            return new DoadorViewModel
            {
                IdPessoa = 4,
                Nome = "Daniel Gomes",
                Cep = "49500000",
                Telefone = "79999221212",
                Bairro = "Centro",
                Cidade = "Itabaiana",
                Cpf = "1824873212",
                Complemento = "Organizacao",
                Latitude = "100",
                Longitude = "100",
                Logradouro = "Av. ",
                NumeroEndereco = "0",
                Uf = "SE",
                DataNascimento = DateTime.Parse("2021-11-4"),
                Email = "teste@email.com",
                Status = "ATIVO",
                Tipo = "DOADOR",
            };

        }

        private static Pessoa GetTargetDoador()
        {
            return new Pessoa
            {
                IdPessoa = 1,
                Nome = "Daniel Gomes",
                Cep = "49500000",
                Telefone = "79999221212",
                Bairro = "Centro",
                Cidade = "Itabaiana",
                Cpf = "1824873212",
                Complemento = "Organizacao",
                Latitude = "100",
                Longitude = "100",
                Logradouro = "Av. ",
                NumeroEndereco = "0",
                Uf = "SE",
                DataNascimento = DateTime.Parse("2021-11-4"),
                Email = "teste@email.com",
                Status = "ATIVO",
                Tipo = "DOADOR",
            };
        }

        private static DoadorViewModel GetTargetDoadorViewModel()
        {
            return new DoadorViewModel
            {
                IdPessoa = 1,
                Nome = "Daniel Gomes",
                Cep = "49500000",
                Telefone = "79999221212",
                Bairro = "Centro",
                Cidade = "Itabaiana",
                Cpf = "1824873212",
                Complemento = "Organizacao",
                Latitude = "100",
                Longitude = "100",
                Logradouro = "Av. ",
                NumeroEndereco = "0",
                Uf = "SE",
                DataNascimento = DateTime.Parse("2021-11-4"),
                Email = "teste@email.com",
                Status = "ATIVO",
                Tipo = "DOADOR",
            };
        }

        private static IEnumerable<Pessoa> GetTestDoador()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    IdPessoa = 1,
                    Nome = "Daniel Gomes",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cpf = "1824873212",
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
                    IdPessoa = 1,
                    Nome = "Daniel Gomes",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cpf = "1824873212",
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
                    IdPessoa = 1,
                    Nome = "Daniel Gomes",
                    Cep = "49500000",
                    Telefone = "79999221212",
                    Bairro = "Centro",
                    Cidade = "Itabaiana",
                    Cpf = "1824873212",
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

            };
        }
    }
}