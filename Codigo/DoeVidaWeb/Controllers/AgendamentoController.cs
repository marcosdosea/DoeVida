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

        // GET: AgendamentoController
        public ActionResult Index()
        {
            var listOrganizacoes = _agendamentoService.GetAll();
            var listOrganizacoesModel = _mapper.Map<List<AgendamentoViewModel>>(listOrganizacoes);
            return View(listOrganizacoesModel);
        }

        // GET: AgendamentoController/Details/5
        public ActionResult Details(int id)
        {
            Core.Agendamento agendamento = _agendamentoService.Get(id);
            AgendamentoViewModel agendamentoModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoModel);
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
            
    }
}
