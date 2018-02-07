using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Joker.IdentityServer4.Resources.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize, Route("api/Identity")]
    public class IdentityController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;

            var isAuthenticated = User.Identity.IsAuthenticated;
            var name = User.Identity.Name;
            var claims = User.Claims.Select(c => new { c.Type, c.Value });

            return Ok(new { UserName = name, IsAuthenticated = isAuthenticated, Claims = claims});
        }
    }
}