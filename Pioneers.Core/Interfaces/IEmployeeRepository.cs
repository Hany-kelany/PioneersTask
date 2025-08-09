using Pioneers.Core.Models;

namespace Pioneers.Core.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IEnumerable<Employee>> GetAllWithPropertiesAsync();
    Task<Employee> GetByIdWithPropertiesAsync(int id);
    // Custum method for only emplyee not in iGenericRepo
}
