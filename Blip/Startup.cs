using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blip.Startup))]
namespace Blip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
