using Domain.Entities;
using System.Collections.Generic;

namespace Model.Interface.Service
{
    public interface IUsuarioService
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
