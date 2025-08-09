using Microsoft.EntityFrameworkCore;
using Pioneers.Core.Interfaces;
using Pioneers.Core.Models;
using Pioneers.InfraStructure.Data;

namespace Pioneers.InfraStructure.Repository;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{

    //Employee custom methods 
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Employee>> GetAllWithPropertiesAsync()
    {
     

        return await context.employees
               .Include(e => e.PropertyValues)
               .ThenInclude(pv => pv.EmployeeProperty)
               .ThenInclude(ep => ep.DropdownOptions)
               .ToListAsync();
    }

    public async Task<Employee> GetByIdWithPropertiesAsync(int id)
    {

        return await context.employees
               .Include(e => e.PropertyValues)
               .ThenInclude(pv => pv.EmployeeProperty)
               .ThenInclude(ep => ep.DropdownOptions)
               .FirstOrDefaultAsync(e => e.Id == id);
    }
}
