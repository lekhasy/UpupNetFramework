using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Upup.Startup))]
namespace Upup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
