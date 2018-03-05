using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autho.Startup))]
namespace Autho
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
