using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hantaton.Startup))]
namespace Hantaton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
