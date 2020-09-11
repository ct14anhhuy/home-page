using Microsoft.Owin;
using Owin;
using Utilities;

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