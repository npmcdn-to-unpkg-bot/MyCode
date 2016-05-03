using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

namespace TLMService
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
