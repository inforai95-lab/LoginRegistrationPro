using LoginRegistrationApp.Models;
using LoginRegistrationApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginRegistrationApp.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(
            IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // READ: Display all employees
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _repository.GetAllAsync();
            return View(employees);
        }

        // READ: Display one employee
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // CREATE: Open form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Save employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            await _repository.AddAsync(employee);

            TempData["Success"] = "Employee added successfully.";

            return RedirectToAction(nameof(Index));
        }

        // UPDATE: Open form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // UPDATE: Save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(employee);

            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _repository.UpdateAsync(employee);

            TempData["Success"] = "Employee updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        // DELETE: Confirmation page
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // DELETE: Confirm deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            TempData["Success"] = "Employee deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}