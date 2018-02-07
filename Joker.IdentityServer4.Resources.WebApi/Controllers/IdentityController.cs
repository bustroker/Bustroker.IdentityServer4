using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Joker.IdentityServer4.Resources.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Identity")]
    public class IdentityController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            var isAuthenticated = User.Identity.IsAuthenticated;
            var name = User.Identity.Name;
            return Ok(new { UserName = name, IsAuthenticated = isAuthenticated, Claims = claims});
        }
    }
}