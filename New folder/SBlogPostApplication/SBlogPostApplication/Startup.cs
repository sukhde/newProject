using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBlogPostApplication.Startup))]
namespace SBlogPostApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
