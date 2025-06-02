using Lab11_GabrielCcama.Domain.Entities;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;

namespace Lab11_GabrielCcama.Domain.Interfaces;

public interface ITicketRepository : IGenericRepository<Ticket>
{
   Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId);
   Task<IEnumerable<Ticket>> GetOpenTicketsAsync();
   Task DeleteTicketAsync(int ticketId); 
}