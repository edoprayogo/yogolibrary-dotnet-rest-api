using System;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Dto;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class CustomerService : ICustomerService
{
    private readonly IRepositoryManager _repositoryManager;

    public CustomerService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cust = await _repositoryManager.CustomerRepository.GetAllAsync(cancellationToken);
        var custDto = cust.Adapt<IEnumerable<CustomerDto>>();
        return custDto;
    }
    public async Task<CustomerDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        var cust = await _repositoryManager.CustomerRepository.GetByIdAsync(ownerId, cancellationToken);
        if (cust is null)
        {
            throw new OwnerNotFoundException(ownerId);
        }
        var custDto = cust.Adapt<CustomerDto>();
        return custDto;
    }
    public async Task<CustomerDto> CreateAsync(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken = default)
    {
        var owner = customerCreateDto.Adapt<Customer>();
        _repositoryManager.CustomerRepository.Insert(owner);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return owner.Adapt<CustomerDto>();
    }
    public async Task UpdateAsync(Guid customerId, CustomerUpdateDto customerUpdateDto, CancellationToken cancellationToken = default)
    {
        var cust = await _repositoryManager.CustomerRepository.GetByIdAsync(customerId, cancellationToken);
        if (cust is null)
        {
            throw new OwnerNotFoundException(customerId);
        }
        // cust.Name = ownerForUpdateDto.Name;
        // cust.DateOfBirth = ownerForUpdateDto.DateOfBirth;
        // cust.Address = ownerForUpdateDto.Address;
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cust = await _repositoryManager.CustomerRepository.GetByIdAsync(customerId, cancellationToken);
        if (cust is null)
        {
            throw new OwnerNotFoundException(customerId);
        }
        _repositoryManager.CustomerRepository.Remove(cust);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
