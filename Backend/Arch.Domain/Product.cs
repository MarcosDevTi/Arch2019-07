using System;
using Arch.Domain.Core;
using Arch.Domain.ValueObjects;

namespace Arch.Domain
{
    public class Product: Entity
    {
        public string Name { get; set; }        
        public string Description { get; set; }
        public Price Price { get; set; }
        public Brand Brand { get; set; }
    }
}