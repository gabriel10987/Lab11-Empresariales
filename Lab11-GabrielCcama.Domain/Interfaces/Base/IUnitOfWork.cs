namespace Lab11_GabrielCcama.Domain.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    ITicketRepository TicketRepository { get; }
    IResponseRepository ResponseRepository { get; }
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}