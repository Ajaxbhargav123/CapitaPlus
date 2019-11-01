using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capitaplus.Startup))]
namespace Capitaplus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
