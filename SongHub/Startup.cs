using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SongHub.Startup))]
namespace SongHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
