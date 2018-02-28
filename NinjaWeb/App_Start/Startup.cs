using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(NinjaWeb.Startup))]
namespace NinjaWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}