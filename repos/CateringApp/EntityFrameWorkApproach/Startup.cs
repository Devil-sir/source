using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityFrameWorkApproach.Startup))]
namespace EntityFrameWorkApproach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
