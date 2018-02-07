using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using IdentityServer4.AccessTokenValidation;

namespace Joker.IdentityServer4.Resources.WebApi
{
    public class OpenIdConnectConfig
    {
        private const string AuthenticationScheme = "Bearer";
        private const string AuthenticationAuthority = "http://localhost:5000";
        private const string ApiId = "api1";

        public static void RegisterIdentityServerInDI(IServiceCollection services)
        {
            services.AddAuthentication(AuthenticationScheme)
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = AuthenticationAuthority;
                   options.RequireHttpsMetadata = false;

                   options.ApiName = ApiId;
               });
        }

        public static void RegisterAuthorization(IMvcCoreBuilder builder)
        {
             builder
                .AddAuthorization()
                .AddJsonFormatters();
        }

        public static void AddIdentityServerToHttpPipeline(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}