using Infrastructure.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Context
{
    public class ContextoIdentity : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ContextoIdentity()
            :base("Conexao", throwIfV1Schema: false)
        {
        }

        public static ContextoIdentity Create()
        {
            return new ContextoIdentity();
        }
    }
}
