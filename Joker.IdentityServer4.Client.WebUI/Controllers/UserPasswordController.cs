using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Joker.IdentityServer4.Client.WebUI.Models;

namespace Joker.IdentityServer4.Client.WebUI.Controllers
{
    public class UserPasswordController : AuthenticationControllerBase
    {
        private const string ApiId = "api1";

        private const string UserPasswordClientId = "userPasswordClient";
        private const string UserPasswordClientSecret = "userPasswordClient-secret";

        public async Task<IActionResult> Index()
        {
            var result = new Model();

            var tokenClient = await GetTokenClientAsync(UserPasswordClientId, UserPasswordClientSecret);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");

            if (tokenResponse.IsError)
            {
                result.RequestTokenError = tokenResponse.Error;
                return View(result);
            }

            result.TokenResponse = tokenResponse.Json.ToString();

            return View(result);
        }
    }
}