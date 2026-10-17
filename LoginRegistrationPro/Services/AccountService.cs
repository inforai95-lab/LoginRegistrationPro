using LoginRegistrationApp.Models;
using LoginRegistrationApp.Repositories.Interfaces;
using LoginRegistrationApp.Services.Interfaces;
using LoginRegistrationApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(
            IUserRepository userRepository,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterAsync(
            RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                FullName = model.FullName.Trim(),
                Email = model.Email.Trim(),
                UserName = model.Email.Trim()
            };

            return await _userRepository.CreateAsync(
                user, model.Password);
        }

        public async Task<SignInResult> LoginAsync(
            LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Email.Trim(),
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);
        }

        public async Task<ApplicationUser?> GetCurrentUserAsync(
            ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}