using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;

namespace Lab11_GabrielCcama.Domain.Interfaces;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<List<Role>> GetByNamesAsync(IEnumerable<string> roleNames);
}