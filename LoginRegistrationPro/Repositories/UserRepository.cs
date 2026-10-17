using LoginRegistrationApp.Models;
using LoginRegistrationApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(
            ApplicationUser user,
            string password)
        {
            return await _userManager.CreateAsync(
                user, password);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(
            string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}