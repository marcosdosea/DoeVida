using AutoMapper;
using Core;
using Core.Service;
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
            var listVagashorariosViewModel = _mapper.Map<List<Vagashorarios>>(listVagashorarios);
            return View(listVagashorariosViewModel);
        }


        // GET: VagasHorarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VagasHorarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VagasHorarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VagasHorarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VagasHorarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VagasHorarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VagasHorarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
