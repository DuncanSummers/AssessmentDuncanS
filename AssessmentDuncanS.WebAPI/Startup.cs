using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssessmentDuncanS.WebAPI.Startup))]
namespace AssessmentDuncanS.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
