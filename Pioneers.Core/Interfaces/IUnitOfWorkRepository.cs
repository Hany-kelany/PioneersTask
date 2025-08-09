using Pioneers.Core.Models;

namespace Pioneers.Core.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        public IEmployeeRepository EmployeeRepository { get; }
        IGenericRepository<CustomProperty> CustomPropertyRepository { get; }
        IGenericRepository<DropdownOption> DropdownOptionRepository { get; }
        IGenericRepository<EmployeePropertyValue> EmployeePropertyValueRepository { get; }
        Task<int> SaveAsync();
    }
}
