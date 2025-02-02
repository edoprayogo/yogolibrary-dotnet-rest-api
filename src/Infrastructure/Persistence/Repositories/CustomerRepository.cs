using System;
using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RepositoryDbContext _dbContext;

    public CustomerRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    Task<IEnumerable<Customer>> ICustomerRepository.GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<Customer> ICustomerRepository.GetByIdAsync(Guid ownerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    void ICustomerRepository.Insert(Customer customer)
    {
        throw new NotImplementedException();
    }

    void ICustomerRepository.Remove(Customer customer)
    {
        throw new NotImplementedException();
    }
}
