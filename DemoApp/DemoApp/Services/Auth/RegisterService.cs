using DemoApp.Components.Account;
using DemoApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using DemoApp.Services.Auth.Models;

namespace DemoApp.Services.Auth
{
    public class RegisterService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEmailSender<ApplicationUser> _emailSender;
        private readonly ILogger<RegisterService> _logger;
        private readonly NavigationManager _navigationManager;
        private readonly IdentityRedirectManager _redirectManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public RegisterService(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            IEmailSender<ApplicationUser> emailSender,
            ILogger<RegisterService> logger,
            NavigationManager navigationManager,
            IdentityRedirectManager redirectManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailSender = emailSender;
            _logger = logger;
            _navigationManager = navigationManager;
            _redirectManager = redirectManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterInputModel input, string? returnUrl)
        {
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, input.Email, CancellationToken.None);
            var emailStore = GetEmailStore();
            await emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                return result;
            }

            _logger.LogInformation("User created a new account with password.");

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = _navigationManager.GetUriWithQueryParameters(
                _navigationManager.ToAbsoluteUri("Account/ConfirmEmail").AbsoluteUri,
                new Dictionary<string, object?> { ["userId"] = userId, ["code"] = code, ["returnUrl"] = returnUrl });

            await _emailSender.SendConfirmationLinkAsync(user, input.Email, HtmlEncoder.Default.Encode(callbackUrl));

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                _redirectManager.RedirectTo(
                    "Account/RegisterConfirmation",
                    new() { ["email"] = input.Email, ["returnUrl"] = returnUrl });
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            _redirectManager.RedirectTo(returnUrl);

            return result;
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
