using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomePageVST.Startup))]

namespace HomePageVST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}