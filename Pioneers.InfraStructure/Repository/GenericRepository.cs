using Microsoft.EntityFrameworkCore;
using Pioneers.Core.Interfaces;
using Pioneers.InfraStructure.Data;
using System.Linq.Expressions;

namespace Pioneers.InfraStructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext context;
    public GenericRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
                 => await context.Set<T>().ToListAsync();
    public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        var query = context.Set<T>().AsQueryable();
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return await query.ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        var query = context.Set<T>().AsQueryable();
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        var entity = query.FirstOrDefault(x => EF.Property<int>(x, "Id") == id);
        return entity;
    }
    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
    async Task<T> IGenericRepository<T>.GetByIdAsync(int id)
    {
        var entity = await context.Set<T>().FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
        return entity;
    }

    public class IemployeeRepository
    {
    }
}
