using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC205_Young.Startup))]
namespace CSC205_Young
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
