using LoginRegistrationApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task AddAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteAsync(int id);
    }
}