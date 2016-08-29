using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CQRS.MVC5.Startup))]
namespace CQRS.MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
