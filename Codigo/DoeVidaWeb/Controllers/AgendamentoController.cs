using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeVidaWeb.Controllers
{
    public class AgendamentoController : Controller
    {

        IAgendamentoService _agendamentoService;
        IMapper _mapper;

        public AgendamentoController(IAgendamentoService agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
        }

        // GET: AgendamentoController/1
        public ActionResult Index(int page=0)
        {
            var listAgendamentos = _agendamentoService.GetFirstTen(page);
            var listAgendamentosModel = _mapper.Map<List<AgendamentoListDTOViewModel>>(listAgendamentos);
            return View(listAgendamentosModel);
        }

        // POST: AgendamentoController/GetCountAll
        [HttpPost]
        public int GetCountAll()
        {
            var _agendamentoCount = _agendamentoService.GetCount();
            return _agendamentoCount;
        }

        // GET: AgendamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgendamentoViewModel agendamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoViewModel);
                _agendamentoService.Insert(agendamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AgendamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            Agendamento agendamento = _agendamentoService.Get(id);
            AgendamentoViewModel agendamentoModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoModel);
        }

        // POST: AgendamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgendamentoViewModel agendamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoViewModel);
                _agendamentoService.Edit(agendamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AgendamentoController/EditStatus/5
        [HttpPost]
        public string EditStatus(int id)
        {
            var _agendamento = _agendamentoService.Get(id);
            _agendamento.Status = "ATENDIDO";
            _agendamentoService.Edit(_agendamento);
            return "Atendido com sucesso!";
        }

    }
}
