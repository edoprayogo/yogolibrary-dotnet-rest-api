using System;

namespace Services.Abstractions;

public interface IServiceManager
{
    ICustomerService CustomerService{get;}
}
