using LoginRegistrationApp.Data;
using LoginRegistrationApp.Models;
using LoginRegistrationApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .AsNoTracking()
                .OrderBy(e => e.EmployeeId)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existing = await _context.Employees
                .FindAsync(employee.EmployeeId);

            if (existing == null)
                return;

            existing.EmployeeName = employee.EmployeeName;
            existing.Email = employee.Email;
            existing.Department = employee.Department;
            existing.Salary = employee.Salary;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}