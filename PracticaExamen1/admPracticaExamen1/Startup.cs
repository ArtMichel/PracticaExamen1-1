using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admPracticaExamen1.Startup))]
namespace admPracticaExamen1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
