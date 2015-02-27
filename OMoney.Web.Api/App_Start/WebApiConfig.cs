using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using OMoney.Web.Api.Filter;

namespace OMoney.Web.Api
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ValidateModelAttribute());

            RouteConfig.RegisterRoutes(config.Routes);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //ADDED
            //jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;

            return config;
        }
    }
}