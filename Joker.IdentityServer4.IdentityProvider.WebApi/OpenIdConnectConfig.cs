using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Joker.IdentityServer4.IdentityProvider.WebApi
{
    public class OpenIdConnectConfig
    {
        public static void RegisterIdentityServerInDI(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(ConfigResourcesAndClients.GetApiResources())
                .AddInMemoryClients(ConfigResourcesAndClients.GetClients());
        }

        public static void AddIdentityServerToHttpPipeline(IApplicationBuilder app)
        {
            app.UseIdentityServer();
        }
    }
}
