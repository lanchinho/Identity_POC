using Domain.Entities;
using Domain.Interface.Repository;
using Model.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Application_Services
{
   public class UsuarioService : IUsuarioService
    {
       private IUsuarioRepository _usuarioRepository;

       public UsuarioService(IUsuarioRepository usuarioRepository)
       {
           _usuarioRepository = usuarioRepository;
       }

        public Usuario ObterPorId(string id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }

        public void DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
        }
    }
}
