using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.EntityConfig
{
   public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
       public UsuarioConfig()
       {
           HasKey(u => u.Id);

           Property(u => u.Id)
               .IsRequired()
               .HasMaxLength(128);

           Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(256);

           Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(256);

           ToTable("AspNetUsers");
       }
    }
}
