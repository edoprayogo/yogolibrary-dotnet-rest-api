using System;
using Domain.Repositories;

namespace Persistence.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;

    public RepositoryManager(RepositoryDbContext dbContext)
    {
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyCustomerRepository = new Lazy<ICustomerRepository>( () => new CustomerRepository(dbContext));
        
    }

    public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}
