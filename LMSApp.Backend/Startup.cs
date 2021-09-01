using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMSApp.Backend.Startup))]
namespace LMSApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
