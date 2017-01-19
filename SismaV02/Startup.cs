using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SismaV02.Startup))]
namespace SismaV02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
