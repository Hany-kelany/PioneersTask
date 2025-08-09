using Pioneers.Core.Interfaces;
using Pioneers.Core.Models;
using Pioneers.InfraStructure.Data;

namespace Pioneers.InfraStructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; }
        public IGenericRepository<CustomProperty> CustomPropertyRepository { get; }
        public IGenericRepository<DropdownOption> DropdownOptionRepository { get; }
        public IGenericRepository<EmployeePropertyValue> EmployeePropertyValueRepository { get; }


        public UnitOfWorkRepository(AppDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(context);
            CustomPropertyRepository = new GenericRepository<CustomProperty>(context);
            DropdownOptionRepository = new GenericRepository<DropdownOption>(context);
            EmployeePropertyValueRepository = new GenericRepository<EmployeePropertyValue>(context);

        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
