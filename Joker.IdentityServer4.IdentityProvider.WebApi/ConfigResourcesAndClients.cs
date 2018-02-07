using IdentityServer4.Models;
using IdentityServer4.Test;
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

        private const string JustClientId = "justClient";
        private const string JustClientSecret = "justClient-secret";

        private const string UserPasswordClientId = "userPasswordClient";
        private const string UserPasswordClientSecret = "userPasswordClient-secret";

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
                    ClientId = JustClientId,
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // no interactive user, use the clientid/secret for authentication

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(JustClientSecret.Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { ApiId }
                },
                new Client
                {
                    ClientId = UserPasswordClientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(UserPasswordClientSecret.Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { ApiId }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
