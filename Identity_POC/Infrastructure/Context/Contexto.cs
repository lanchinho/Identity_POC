using System.Data.Entity;
using Domain.Entities;
using Infrastructure.EntityConfig;

namespace Infrastructure.Context
{
    public class Contexto : DbContext
    {
        //TODO: LEmbrar de chamar minha conexão de Conexão
        public Contexto()
            :base("Conexao")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
