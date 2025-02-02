using System;
using Domain.Entities;

namespace Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Customer> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    void Insert(Customer customer);
    void Remove(Customer customer);
}
