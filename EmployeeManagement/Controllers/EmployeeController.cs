using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize] //authorised for all end points.
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees - Fetch all employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        // GET: api/employees/{id} - Fetch employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        // POST: api/employees - Create a new employee
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            var newEmployee = await _employeeService.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.Id }, newEmployee);
        }

        // PUT: api/employees/{id} - Update an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = await _employeeService.UpdateEmployee(id, updatedEmployee);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        // DELETE: api/employees/{id} - Delete an employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteEmployee(id);
            if (!deleted)
                return NotFound($"Employee with ID {id} not found.");

            return NoContent();
        }
    }
}
