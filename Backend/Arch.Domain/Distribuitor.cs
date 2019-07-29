using System.Collections.Generic;
using Arch.Domain.Core;

namespace Arch.Domain
{
    public class Distribuitor: Entity
    {
        public string Name { get; set; }
        IEnumerable<Brand> Brands {get;set;}
    }
}