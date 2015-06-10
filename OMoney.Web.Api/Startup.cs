using System;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using OMoney.Web.Api;
using OMoney.Web.Api.Providers;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace OMoney.Web.Api
{
    public class Startup
    {

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
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(30),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServiceOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }


    }
}