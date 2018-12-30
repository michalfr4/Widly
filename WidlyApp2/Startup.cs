using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WidlyApp2.Startup))]
namespace WidlyApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
