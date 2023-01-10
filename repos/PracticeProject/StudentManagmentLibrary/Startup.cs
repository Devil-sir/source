using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentManagmentLibrary.Startup))]
namespace StudentManagmentLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
