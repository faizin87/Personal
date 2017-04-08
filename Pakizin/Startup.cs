using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pakizin.Startup))]
namespace Pakizin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
