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
using OMoney.Data.Users;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Users;


[assembly: OwinStartup(typeof(OMoney.Web.Api.Startup))]
namespace OMoney.Web.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
            app.UseWebApi(config);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}