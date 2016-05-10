using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using TLMManager.Service;

[assembly: OwinStartup(typeof(TLMManager.Startup))]

namespace TLMManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
 

            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}