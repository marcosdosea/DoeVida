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
    public class ItemControllerTests
    {
        private static ItemController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IItemService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ItemProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestItem());

            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetItem());
            mockService.Setup(service => service.Edit(It.IsAny<Item>()))
                .Verifiable();
            mockService.Setup(service => service.Insert(It.IsAny<Item>()))
                .Verifiable();

            controller = new ItemController(mockService.Object, mapper);
        }

        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewItem());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewItem());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ItemViewModel));
            ItemViewModel itemViewmodel = (ItemViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Recipiente Tipo A", itemViewmodel.Nome);
            Assert.AreEqual("DISPONIVEL", itemViewmodel.Status);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetItemViewModel().IdItem, GetTargetItemViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ItemViewModel));
            ItemViewModel itemviewmodel = (ItemViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Recipiente Tipo A", itemviewmodel.Nome);
        }


        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetItemViewModel().IdItem, GetTargetItemViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static IEnumerable<Item> GetTestItem()
        {
            return new List<Item>
            {
                new Item
                {
                    IdItem = 1,
                    Nome = "Recipiente Tipo A",
                    IdOrganizacao = 253,
                    Quantidade =    2,
                    Status = "DISPONIVEL",
                    Tipo =  "TESTE"
                },
                new Item
                {
                    IdItem = 2,
                    Nome = "Recipiente Tipo b",
                    IdOrganizacao = 253,
                    Quantidade =    0,
                    Status = "INDISPONIVEL",
                    Tipo =  "TESTE"
                },

            };
        }
        private static ItemViewModel GetNewItem()
        {
            return new ItemViewModel
            {
                IdItem = 1,
                Nome = "Recipiente Tipo A",
                IdOrganizacao = 253,
                Quantidade = 2,
                Status = "DISPONIVEL",
                Tipo = "TESTE"
            };

        }
        private static Item GetTargetItem()
        {
            return new Item
            {
                IdItem = 1,
                Nome = "Recipiente Tipo A",
                IdOrganizacao = 253,
                Quantidade = 2,
                Status = "DISPONIVEL",
                Tipo = "TESTE"
            };
        }
        private static ItemViewModel GetTargetItemViewModel()
        {
            return new ItemViewModel
            {
                IdItem = 1,
                Nome = "Recipiente Tipo A",
                IdOrganizacao = 253,
                Quantidade = 2,
                Status = "DISPONIVEL",
                Tipo = "TESTE"
            };
        }


    }
}