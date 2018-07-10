using Microsoft.Owin;
using Owin;
using PressfordConsulting.News;

[assembly: OwinStartup(typeof(Startup))]
namespace PressfordConsulting.News
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
