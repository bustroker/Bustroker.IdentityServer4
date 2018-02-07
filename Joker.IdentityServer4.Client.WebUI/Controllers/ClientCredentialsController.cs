using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Joker.IdentityServer4.Client.WebUI.Models;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Joker.IdentityServer4.Client.WebUI.Controllers
{
    public class ClientCredentialsController : AuthenticationControllerBase
    {
        private const string ApiId = "api1";

        private const string JustClientId = "justClient";
        private const string JustClientSecret = "justClient-secret";

        public async Task<IActionResult> Index()
        {
            var result = new Model();

            var tokenClient = await GetTokenClientAsync(JustClientId, JustClientSecret);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(ApiId);

            if (tokenResponse.IsError)
            {
                result.RequestTokenError = tokenResponse.Error;
                return View(result);
            }

            result.TokenResponse = tokenResponse.Json.ToString();

            // call api
            using (var client = new HttpClient())
            {
                client.SetBearerToken(tokenResponse.AccessToken);

                var response = await client.GetAsync("http://localhost:5001/api/identity");
                if (!response.IsSuccessStatusCode)
                {
                    result.ApiErrorStatusCode = response.StatusCode.ToString();
                    return View(result);
                }
                var content = await response.Content.ReadAsStringAsync();
                result.ApiResponseContent = content;
                return View(result);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
