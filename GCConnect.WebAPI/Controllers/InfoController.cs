using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InfoController : ControllerBase
    {
        // GET: api/whoami
        [HttpGet]
        [Route("whoami")]
        public Dictionary<string, string>? GetAuthorized()
        {
            var principal = (ClaimsPrincipal?)User.Identity;
            return principal?.Claims
               .GroupBy(claim => claim.Type)
               .ToDictionary(claim => claim.Key, claim => claim.First().Value);
        }

        // GET: api/hello
        [HttpGet]
        [Route("hello")]
        [AllowAnonymous]
        public string GetAnonymous()
        {
            return "You are anonymous";
        }
    }
}