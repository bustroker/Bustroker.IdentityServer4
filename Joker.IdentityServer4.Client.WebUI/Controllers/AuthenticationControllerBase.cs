using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joker.IdentityServer4.Client.WebUI.Controllers
{
    public class AuthenticationControllerBase : Controller
    {
        private const string AuthenticationAuthority = "http://localhost:5000";

        protected async Task<TokenClient> GetTokenClientAsync(string clientId, string clientSecret)
        {
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync(AuthenticationAuthority);
            if (disco.IsError)
            {
                throw new ApplicationException($"Discovery error => {disco.Error}");
            }

            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, clientId, clientSecret);
            return tokenClient;
        }

    }
}
