using System;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using OMoney.Data.Users;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Users;
using OMoney.Web.Api;
using OMoney.Web.Api.Providers;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OMoney.Web.Api
{
    public class Startup
    {
        //[Inject]
        //public IUserService UserService { get; set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(NinjectWebCommon.CreateKernel).UseNinjectWebApi(WebApiConfig.Register());
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServiceOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServiceOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }


    }
}