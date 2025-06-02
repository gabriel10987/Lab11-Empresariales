using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces;
using Lab11_GabrielCcama.Infrastructure.Context;
using Lab11_GabrielCcama.Infrastructure.Repositories.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace Lab11_GabrielCcama.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

}