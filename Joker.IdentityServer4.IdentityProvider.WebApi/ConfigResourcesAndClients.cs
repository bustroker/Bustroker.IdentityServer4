using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joker.IdentityServer4.IdentityProvider.WebApi
{
    public class ConfigResourcesAndClients
    {

        private const string AuthenticationScheme = "Bearer";
        private const string AuthenticationAuthority = "http://localhost:5000";
        private const string ApiId = "api1";
        private const string ApiPrettyName = "API 1";

        private const string ClientId = "client";
        private const string ClientSecret = "secret";


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(ApiId, ApiPrettyName)
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = ClientId,

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(ClientSecret.Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { ApiId }
                }
            };
        }
    }
}
