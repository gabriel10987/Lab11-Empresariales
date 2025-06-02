using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces;
using Lab11_GabrielCcama.Infrastructure.Context;
using Lab11_GabrielCcama.Infrastructure.Repositories.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace Lab11_GabrielCcama.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<List<Role>> GetByNamesAsync(IEnumerable<string> roleNames)
    {
        return await _context.Roles
            .Where(r => roleNames.Contains(r.RoleName))
            .ToListAsync();
    }

}