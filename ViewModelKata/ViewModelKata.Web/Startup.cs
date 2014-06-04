using Microsoft.Owin;
using Owin;
using ViewModelKata.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace ViewModelKata.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
