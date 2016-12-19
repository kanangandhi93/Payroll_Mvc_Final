using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Payroll_Mvc.Startup))]
namespace Payroll_Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
