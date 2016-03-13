using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABCSafeHaven.Startup))]
namespace ABCSafeHaven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
