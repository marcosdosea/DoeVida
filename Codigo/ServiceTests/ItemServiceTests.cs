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
    public class ItemServiceTest
    {
        private DoeVidaDbContext _context;
        private IItemService _itemService;

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
            var itens = new List<Item>
                {
                 new Item
                {
                    IdItem = 1,
                    Nome = "Recipiente Tipo A",
                    IdOrganizacao = 253,
                    Quantidade =    2,
                    Status = "DISPONIVEL",
                    Tipo =  "TESTE1"
                },
                 new Item
                {
                    IdItem = 2,
                    Nome = "Recipiente Tipo B",
                    IdOrganizacao = 253,
                    Quantidade =    10,
                    Status = "DISPONIVEL",
                    Tipo =  "TESTE2"
                },
                 new Item
                {
                    IdItem = 3,
                    Nome = "Recipiente Tipo C",
                    IdOrganizacao = 253,
                    Quantidade =    5,
                    Status = "DISPONIVEL",
                    Tipo =  "TESTE3"
                }
                };

            _context.AddRange(itens);
            _context.SaveChanges();

            _itemService = new ItemService(_context);
        }

        [TestMethod()]
        public void InsertTest()
        {
            // Act
            _itemService.Insert(new Item
            {
                IdItem = 3,
                Nome = "Recipiente Tipo A",
                IdOrganizacao = 253,
                Quantidade = 2,
                Status = "DISPONIVEL",
                Tipo = "TESTE1"
            });
            // Assert
            Assert.AreEqual(4, _itemService.GetAll().Count());
            var item = _itemService.Get(4);
            Assert.AreEqual(1, item.IdItem);
        }

        [TestMethod()]
        public void EditTest()
        {
            var item = _itemService.Get(3);
            item.Tipo = "TESTE";
            _itemService.Edit(item);
            item = _itemService.Get(3);
            Assert.AreEqual("TESTE", item.Tipo);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _itemService.Delete(2);
            // Assert
            Assert.AreEqual(2, _itemService.GetAll().Count());
            var item = _itemService.Get(2);
            Assert.AreEqual(null, item);
        }


        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaItem = _itemService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaItem, typeof(IEnumerable<Item>));
            Assert.IsNotNull(listaItem);
            Assert.AreEqual(3, listaItem.Count());
            Assert.AreEqual(1, listaItem.First().IdItem);
            Assert.AreEqual("Recipiente Tipo A", listaItem.First().Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var item = _itemService.Get(1);
            Assert.IsNotNull(item);
            Assert.AreEqual("Recipiente Tipo A", item.Nome);
            Assert.AreEqual("TESTE", item.Tipo);
        }



        [TestMethod()]
        public void GetAllOrderByNameTest()
        {
            // Act
            var ListaItem = _itemService.GetAllOrderByName();
            // Assert
            Assert.IsInstanceOfType(ListaItem, typeof(IEnumerable<Item>));
            Assert.IsNotNull(ListaItem);
            Assert.AreEqual(3, ListaItem.Count());
            Assert.AreEqual(1, ListaItem.First().IdItem);
        }

        [TestMethod()]
        public void GetByNameContainedTest()
        {
            // Act
            var ListaItem = _itemService.GetByNameContained("3");
            // Assert
            Assert.IsInstanceOfType(ListaItem, typeof(IEnumerable<Item>));
            Assert.IsNotNull(ListaItem);
            Assert.AreEqual(1, ListaItem.Count());
            Assert.AreEqual(3, ListaItem.First().IdOrganizacao);
        }
        
        [TestMethod()]
        public void GetDTOById()
        {
            var ListaItem = _itemService.GetDTO(1);

            Assert.IsInstanceOfType(ListaItem, typeof(IEnumerable<Item>));
            Assert.IsNotNull(ListaItem);
            Assert.AreEqual(1, ListaItem.Count());
            Assert.AreEqual(2, ListaItem.First().IdOrganizacao);
        }

    }
}