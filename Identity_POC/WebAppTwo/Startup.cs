using Microsoft.Owin;
using Owin;
using WebAppTwo;

[assembly: OwinStartup(typeof(Startup))]

namespace WebAppTwo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
