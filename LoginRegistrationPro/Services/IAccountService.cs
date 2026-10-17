using LoginRegistrationApp.Models;
using LoginRegistrationApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(
            RegisterViewModel model);

        Task<SignInResult> LoginAsync(
            LoginViewModel model);

        Task<ApplicationUser?> GetCurrentUserAsync(
            System.Security.Claims.ClaimsPrincipal principal);

        Task LogoutAsync();
    }
}