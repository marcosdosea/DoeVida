using AutoMapper;
using Core;
using Core.Service;
using DoeVidaWeb.Areas.Identity.Data;
using DoeVidaWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoeVidaWeb.Controllers
{
    public class DoadorController : Controller
    {
        IDoadorService _doadorService;
        IMapper _mapper;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public DoadorController(
            IDoadorService doadorService,
            IMapper mapper,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _doadorService = doadorService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Index()
        {
            var listDoador = _doadorService.GetAll();
            var listDoadorModel = _mapper.Map<List<DoadorViewModel>>(listDoador);
            return View(listDoadorModel);
        }

        // GET: DoadorController/Details/5
        public Pessoa Details(int id)
        {
            Pessoa doador = _doadorService.Get(id);
            return doador;
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

        // GET: DoadorController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: DoadorController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAsync(DoadorViewModel doadorModel)
        {
            if (ModelState.IsValid)
            {
                var doador = _mapper.Map<Pessoa>(doadorModel);
                var user = new Usuario { UserName = doadorModel.Email, Email = doadorModel.Email };
                var result = await _userManager.CreateAsync(user, doadorModel.Password);
                if (result.Succeeded)
                {
                    _doadorService.Insert(doador);
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
