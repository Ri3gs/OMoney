using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Owin;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using OMoney.Domain.Services.Users;


[assembly: OwinStartup(typeof(OMoney.Web.Api.Startup))]
namespace OMoney.Web.Api
{
    public class Startup
    {
        [Inject]
        public IUserService UserService { get; set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseNinjectMiddleware(NinjectWebCommon.CreateKernel).UseNinjectWebApi(WebApiConfig.Register());
        }

    }
}