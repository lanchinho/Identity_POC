using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using Domain.Entities;
using Domain.Interface.Repository;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository()
        {
            _contexto = new Contexto();
        }

        public Usuario ObterPorId(string id)
        {
            return _contexto.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _contexto.Usuarios.ToList();
        }

        public void DesativarLock(string id)
        {
            _contexto.Usuarios.Find(id).LockoutEnabled = false;
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
