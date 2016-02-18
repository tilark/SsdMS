using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SsdMS.Startup))]
namespace SsdMS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
