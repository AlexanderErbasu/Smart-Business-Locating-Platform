using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPP_Final.Startup))]
namespace BPP_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
