using DemoApp.Components.Account;
using DemoApp.Data;
using Microsoft.AspNetCore.Identity;

namespace DemoApp.Services.Auth
{
    public class LoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginService> _logger;
        private readonly IdentityRedirectManager _redirectManager;

        public LoginService(
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginService> logger,
            IdentityRedirectManager redirectManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _redirectManager = redirectManager;
        }

        public async Task<bool> LoginUserAsync(Models.LoginInputModel input, string? returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, input.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                _redirectManager.RedirectTo(returnUrl);
                return true;
            }
            else if (result.RequiresTwoFactor)
            {
                _redirectManager.RedirectTo(
                    "Account/LoginWith2fa",
                    new() { ["returnUrl"] = returnUrl, ["rememberMe"] = input.RememberMe });
                return false;
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                _redirectManager.RedirectTo("Account/Lockout");
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
