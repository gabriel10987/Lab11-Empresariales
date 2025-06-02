using Lab11_GabrielCcama.Domain.Interfaces;
using Lab11_GabrielCcama.Domain.Interfaces.Base;
using Lab11_GabrielCcama.Infrastructure.Context;

namespace Lab11_GabrielCcama.Infrastructure.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ITicketRepository TicketRepository { get; }
    public IResponseRepository ResponseRepository { get; }

    public UnitOfWork(ApplicationDbContext context, 
        IUserRepository userRepository, 
        IRoleRepository roleRepository, 
        ITicketRepository ticketRepository, 
        IResponseRepository responseRepository)
    {
        _context = context;
        UserRepository = userRepository;
        RoleRepository = roleRepository;
        TicketRepository = ticketRepository;
        ResponseRepository = responseRepository;
    }
    
    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            var repoInstance = new GenericRepository<TEntity>(_context);
            _repositories[type] = repoInstance;
        }
        return (IGenericRepository<TEntity>)_repositories[type];
    }
    
    public async Task<int> Complete() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}