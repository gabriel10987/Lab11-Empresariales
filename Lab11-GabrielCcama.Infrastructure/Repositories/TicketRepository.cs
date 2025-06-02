using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces;
using Lab11_GabrielCcama.Infrastructure.Context;
using Lab11_GabrielCcama.Infrastructure.Repositories.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace Lab11_GabrielCcama.Infrastructure.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
    {
        return await _context.Tickets.Where(t => t.UserId == userId).ToListAsync();
    }
    
    public async Task<IEnumerable<Ticket>> GetOpenTicketsAsync()
    {
        return await _context.Tickets.Where(t => t.Status == "abierto").ToListAsync();
    }

    public async Task DeleteTicketAsync(int ticketId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
        }
    }

}