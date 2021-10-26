using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoeVidaWeb.Controllers
{
    public class DoadorController : Controller
    {
        IDoadorService _doadorService;
        IMapper _mapper;

        public DoadorController(IDoadorService doadorService, IMapper mapper)
        {
            _doadorService = doadorService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listDoador = _doadorService.GetAll();
            var listDoadorModel = _mapper.Map<List<DoadorViewModel>>(listDoador);
            return View(listDoadorModel);
        }

        // GET: DoadorController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa doador = _doadorService.Get(id);
            DoadorViewModel doadorModel = _mapper.Map<DoadorViewModel>(doador);
            return View(doadorModel);
        }

        // GET: DoadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoadorViewModel doadorModel)
        {
            if (ModelState.IsValid)
            {
                var doador = _mapper.Map<Pessoa>(doadorModel);
                _doadorService.Insert(doador);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DoadorController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa doador = _doadorService.Get(id);
            DoadorViewModel doadorModel = _mapper.Map<DoadorViewModel>(doador);
            return View(doadorModel);
        }

        // POST: DoadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DoadorViewModel doadorModel)
        {
            if (ModelState.IsValid)
            {
                var doador = _mapper.Map<Pessoa>(doadorModel);
                _doadorService.Edit(doador);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DoadorController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa doador = _doadorService.Get(id);
            DoadorViewModel doadorModel = _mapper.Map<DoadorViewModel>(doador);
            return View(doadorModel);
        }

        // POST: DoadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DoadorViewModel doadorModel)
        {
            _doadorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
