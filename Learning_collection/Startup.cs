using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Learning_collection.Startup))]
namespace Learning_collection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
