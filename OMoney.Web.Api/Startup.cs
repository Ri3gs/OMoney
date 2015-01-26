using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using OMoney.Domain.Services.Users;
using OMoney.Web.Api;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OMoney.Web.Api
{
    public class Startup
    {
        [Inject]
        public IUserService UserService { get; set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(NinjectWebCommon.CreateKernel).UseNinjectWebApi(WebApiConfig.Register());
        }

    }
}