using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SnowTails.WebMVC.Startup))]
namespace SnowTails.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
