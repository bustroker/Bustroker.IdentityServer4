using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Joker.IdentityServer4.IdentityProvider.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OpenIdConnectConfig.ConfigureRegisterIdentityServerInDI(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            OpenIdConnectConfig.AddIdentityServerToHttpPipeline(app);
        }
    }
}
