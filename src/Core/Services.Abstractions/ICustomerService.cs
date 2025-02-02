using System;
using Dto;

namespace Services.Abstractions;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CustomerDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<CustomerDto> CreateAsync(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid customerId, CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default);

}
