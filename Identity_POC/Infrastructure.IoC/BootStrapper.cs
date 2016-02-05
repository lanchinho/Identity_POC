using Domain.Interface.Repository;
using Infrastructure.Repository;
using SimpleInjector;
using Infrastructure.Identity.Context;
using Infrastructure.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using Infrastructure.Identity.Configuration;
using Microsoft.AspNet.Identity;

namespace Infrastructure.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<ContextoIdentity>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ContextoIdentity()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            container.RegisterPerWebRequest<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
