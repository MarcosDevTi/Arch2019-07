using Arch.Domain.Core;

namespace Arch.Domain
{
    public class Brand: Entity
    {
        public string Name { get; set; }
        public Distribuitor Distribuitor {get;set;}
    }
}