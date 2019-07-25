using System.Collections.Generic;
using Arch.CrossCutting.CqrsContracts;

namespace Arch.Cqrs.Client.Customer
{
    public class GetCustomers: IQuery<IReadOnlyList<CustomerItem>>
    {
        public int Take { get; set; }
    }
}