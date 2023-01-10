using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CateringApp.Startup))]
namespace CateringApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
