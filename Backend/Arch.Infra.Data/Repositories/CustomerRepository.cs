using Arch.Domain;
using Arch.Domain.Contracts;

namespace Arch.Infra.Data.Repositories
{
    public class CustomerRepository:
        Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ArchContext context)
            :base(context) {}
    }
}