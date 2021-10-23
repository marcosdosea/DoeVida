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
    public class OrganizacaoController : Controller
    {

        IOrganizacaoService _organizacaoService;
        IMapper _mapper;

        public OrganizacaoController(IOrganizacaoService organizacaoService, IMapper mapper)
        {
            _organizacaoService = organizacaoService;
            _mapper = mapper;
        }


        // GET: OrganizacaoController
        public ActionResult Index()
        {
            var listOrganizacoes = _organizacaoService.GetAll();
            var listOrganizacoesModel = _mapper.Map<List<OrganizacaoViewModel>>(listOrganizacoes);
            return View(listOrganizacoesModel);
        }

        // GET: OrganizacaoController/Details/5
        public ActionResult Details(int id)
        {
            Organizacao organizacao = _organizacaoService.Get(id);
            OrganizacaoViewModel organizacaoModel = _mapper.Map<OrganizacaoViewModel>(organizacao);
            return View(organizacaoModel);
        }

        // GET: OrganizacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizacaoViewModel organizacaoModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoModel);
                _organizacaoService.Insert(organizacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrganizacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            Organizacao organizacao = _organizacaoService.Get(id);
            OrganizacaoViewModel organizacaoModel = _mapper.Map<OrganizacaoViewModel>(organizacao);
            return View(organizacaoModel);
        }

        // POST: OrganizacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizacaoViewModel organizacaoModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoModel);
                _organizacaoService.Edit(organizacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrganizacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            Organizacao organizacao = _organizacaoService.Get(id);
            OrganizacaoViewModel organizacaoModel = _mapper.Map<OrganizacaoViewModel>(organizacao);
            return View(organizacaoModel);
        }

        // POST: OrganizacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrganizacaoViewModel organizacaoModel)
        {
            _organizacaoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
