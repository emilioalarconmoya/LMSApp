using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMSAppBackend.Startup))]
namespace LMSAppBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
