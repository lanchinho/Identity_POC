using Domain.Interface.Repository;
using Model.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTwo.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            //TODO : Isolar Repository em serviços de app.
            _usuarioService = usuarioService;
        }


        public ActionResult Index()
        {
            return View(_usuarioService.ObterTodos());
        }


        public ActionResult Details(string id)
        {
            return View(_usuarioService.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _usuarioService.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}