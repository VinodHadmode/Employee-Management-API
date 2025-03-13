using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);

        Task<Employee> CreateEmployee(Employee employee);

        Task<Employee?> UpdateEmployee(int id, Employee updatedEmployee);

        Task<bool> DeleteEmployee(int id);
    }
}
