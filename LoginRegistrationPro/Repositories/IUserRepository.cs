using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(
            ApplicationUser user,
            string password);

        Task<ApplicationUser?> GetByEmailAsync(
            string email);
    }
}