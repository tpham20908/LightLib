using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LightLib.Startup))]
namespace LightLib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
