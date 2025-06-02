using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab11_GabrielCcama.Infrastructure.Repositories.Base;

public class GenericRepository<T>: IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
    public async Task AddAsync(T entity) 
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}