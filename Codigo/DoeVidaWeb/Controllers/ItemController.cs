using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeVidaWeb.Controllers
{
    [Authorize(Roles = "SERVIDOR")]
    public class ItemController : Controller
    {
        IItemService _itemService;
        IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }


        // GET: ItemController
        public ActionResult Index(int id)
        {
            ViewBag.currentPage = id;
            ViewBag.totalPages = GetTotalPages(_itemService.GetCount());
            var listItens = _itemService.GetTakePage(id, 10);
            var listItensViewModel = _mapper.Map<List<ItemListDTOViewModel>>(listItens);
            return View(listItensViewModel);
        }

        // GET: ItemController/Details/5
        public IEnumerable<ItemListDTO> Details(int id) 
        {
             var item = _itemService.GetDTO(id);


            return item;
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemViewModel itemModel)
        {

            var item = _mapper.Map<Item>(itemModel);
            _itemService.Insert(item);

            return RedirectToAction(nameof(Index));
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            Item item = _itemService.Get(id);
            ItemListDTOViewModel itemModel = _mapper.Map<ItemListDTOViewModel>(item);
            return View(itemModel);
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemViewModel itemModel)
        {
            if (ModelState.IsValid)
            {
                var item = _mapper.Map<Item>(itemModel);
                _itemService.Edit(item);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            Item item = _itemService.Get(id);
            ItemViewModel itemModel = _mapper.Map<ItemViewModel>(item);
            return View(itemModel);
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ItemViewModel itemModel)
        {
            _itemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public int GetTotalPages(int totalItens)
        {
            if (totalItens % 10 != 0)
            {
                return (totalItens / 10) + 1;
            }
            return totalItens / 10;
        }
    }
}
