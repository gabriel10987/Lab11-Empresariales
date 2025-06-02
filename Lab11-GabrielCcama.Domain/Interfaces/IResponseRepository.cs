using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Scaffold;

namespace Lab11_GabrielCcama.Domain.Interfaces;

public interface IResponseRepository :  IGenericRepository<Response>
{
    Task<IEnumerable<Response>> GetResponsesByTicketIdAsync(int ticketId);
    Task AddResponseAsync(Response response);
}