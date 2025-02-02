using System;

namespace Domain.Repositories;

public interface IRepositoryManager
{
    IUnitOfWork UnitOfWork{get;}
    ICustomerRepository CustomerRepository{get;}

}
