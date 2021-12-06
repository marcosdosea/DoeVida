using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoeVidaWeb.Controllers
{
    public class VagasHorariosController : Controller
    {
        IVagasHorariosService _vagasHorariosService;
        IMapper _mapper;

        public VagasHorariosController(IVagasHorariosService vagasHorariosService, IMapper mapper)
        {
            _vagasHorariosService = vagasHorariosService;
            _mapper = mapper;
        }

        // GET: VagasHorarios
        public ActionResult Index(int id)
        {
            ViewBag.currentPage = id;
            ViewBag.totalPages = GetTotalPages(_vagasHorariosService.GetCount());
            var listVagashorarios = _vagasHorariosService.GetTakePage(id, 10);
            var listVagashorariosViewModel = _mapper.Map<List<VagasHorariosViewModel>>(listVagashorarios);
            return View(listVagashorariosViewModel);
        }


        // GET: VagasHorarios/Details/5
        public ActionResult Details(int id)
        {
            Vagashorarios vagasHorarios = _vagasHorariosService.Get(id);
            VagasHorariosViewModel vagasHorariosModel = _mapper.Map<VagasHorariosViewModel>(vagasHorarios);
            return View(vagasHorariosModel);
        }

        // GET: VagasHorarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VagasHorarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VagasHorariosViewModel vagasHorariosModel)
        {
            if (ModelState.IsValid)
            {
                var vagasHorarios = _mapper.Map<Vagashorarios>(vagasHorariosModel);
                _vagasHorariosService.Insert(vagasHorarios);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VagasHorarios/Edit/5
        public ActionResult Edit(int id)
        {
            Vagashorarios vagasHorarios = _vagasHorariosService.Get(id);
            VagasHorariosViewModel vagasHorariosModel = _mapper.Map<VagasHorariosViewModel>(vagasHorarios);
            return View(vagasHorariosModel);
        }

        // POST: VagasHorarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VagasHorariosViewModel vagasHorariosModel)
        {
            if (ModelState.IsValid)
            {
                var vagasHorarios = _mapper.Map<Vagashorarios>(vagasHorariosModel);
                _vagasHorariosService.Edit(vagasHorarios);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VagasHorarios/Delete/5
        public ActionResult Delete(int id)
        {
            Vagashorarios vagasHorarios = _vagasHorariosService.Get(id);
            VagasHorariosViewModel vagasHorariosModel = _mapper.Map<VagasHorariosViewModel>(vagasHorarios);
            return View(vagasHorariosModel);
        }

        // POST: VagasHorarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VagasHorariosViewModel vagasHorariosModel)
        {
            _vagasHorariosService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private int GetTotalPages(int totalItens)
        {
            if (totalItens % 10 != 0)
            {
                return (totalItens / 10) + 1;
            }
            return totalItens / 10;
        }
    }
}
