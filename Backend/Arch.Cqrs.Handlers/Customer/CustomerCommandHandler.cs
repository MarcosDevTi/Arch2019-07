using Arch.Cqrs.Client.Customer;
using Arch.CrossCutting.CqrsContracts;
using Arch.Domain.Contracts;
using Arch.Domain.ValueObjects;
using AutoMapper;

namespace Arch.Cqrs.Handlers.Customer
{
    public class CustomerCommandHandler :
        ICommandHandler<CreateCustomer>
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(CreateCustomer command)
        {
            var customer = Mapper.Map<Domain.Customer>(command);
            
            _customerRepository.Add(customer);
            _customerRepository.Save();
        }
    }
}