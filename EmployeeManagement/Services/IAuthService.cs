using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IAuthService
    {
        string Authenticate(User user);
    }
}
