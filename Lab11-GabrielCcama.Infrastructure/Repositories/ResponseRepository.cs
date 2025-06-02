using Lab11_GabrielCcama.Domain.Interfaces;
using Lab11_GabrielCcama.Infrastructure.Context;
using Lab11_GabrielCcama.Infrastructure.Repositories.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace Lab11_GabrielCcama.Infrastructure.Repositories;

public class ResponseRepository : GenericRepository<Response>, IResponseRepository
{
    private readonly ApplicationDbContext _context;

    public ResponseRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Response>> GetResponsesByTicketIdAsync(int ticketId)
    {
        return await _context.Responses.Where(r => r.TicketId == ticketId).ToListAsync();
    }
    
    public async Task AddResponseAsync(Response response)
    {
        await _context.Responses.AddAsync(response);
    }

}