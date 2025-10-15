using AuthServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace AuthCenter.Controllers
{
    [ApiController]
    [Route("connect")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("token"), Produces("application/json")]
        public async Task<IActionResult> Exchange(OpenIddictRequest request)
        {
            if (request.GrantType == GrantTypes.Password)
            {
                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null)
                    return Forbid();

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
                if (!result.Succeeded)
                    return Forbid();

                var principal = await _signInManager.CreateUserPrincipalAsync(user);
                principal.SetScopes(Scopes.OpenId, Scopes.Email, Scopes.Profile);

                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            return BadRequest(new { error = "Unsupported grant type" });
        }
    }
}
