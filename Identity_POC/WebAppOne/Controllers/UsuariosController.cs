﻿using Domain.Interface.Repository;
using System.Web.Mvc;

namespace WebAppOne.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public ActionResult Index()
        {
            return View(_usuarioRepository.ObterTodos());
        }


        public ActionResult Details(string id)
        {
            return View(_usuarioRepository.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}