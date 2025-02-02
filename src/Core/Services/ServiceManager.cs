using System;
using Domain.Repositories;
using Services.Abstractions;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICustomerService> _lazyCustomerService;
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyCustomerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager));
    }

    public ICustomerService CustomerService => _lazyCustomerService.Value;
}
