using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneraslStore.MVC.Startup))]
namespace GeneraslStore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
