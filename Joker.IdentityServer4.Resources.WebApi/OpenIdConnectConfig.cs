using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Joker.IdentityServer4.Resources.WebApi
{
    internal class OpenIdConnectConfig
    {
        public static void RegisterIdentityServerInDI(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = "http://localhost:5000";
                   options.RequireHttpsMetadata = false;

                   options.ApiName = "api1";
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