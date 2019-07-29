using System.Collections.Generic;
using System.Linq;
using Arch.Domain.Core;
using Arch.Domain.ValueObjects;

namespace Arch.Domain
{
    public class Order: Entity
    {
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}