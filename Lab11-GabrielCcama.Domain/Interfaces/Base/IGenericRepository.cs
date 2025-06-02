namespace Lab11_GabrielCcama.Domain.Interfaces.Base;

public interface IGenericRepository<T> where  T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void UpdateAsync(T entity);
    Task DeleteAsync(int id);
}