using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BykesProject.Startup))]
namespace BykesProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
