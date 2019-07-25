using System.Collections.Generic;
using System.Linq;
using Arch.Cqrs.Client.Customer;
using Arch.CrossCutting.CqrsContracts;
using Arch.Domain.Contracts;

namespace Arch.Cqrs.Handlers.Customer
{
    public class CustomerQueryHandler :
        IQueryHandler<GetCustomers, IReadOnlyList<CustomerItem>>
    {
         public readonly ICustomerRepository _customerRepository;

        public CustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IReadOnlyList<CustomerItem> Handle(GetCustomers query)
        {
            return _customerRepository.Get<CustomerItem>().ToList();
        }
    }
}