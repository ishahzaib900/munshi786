using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Munshi786.Startup))]
namespace Munshi786
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
