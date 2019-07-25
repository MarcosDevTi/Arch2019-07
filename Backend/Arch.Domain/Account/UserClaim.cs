using Arch.Domain.Core;

namespace Arch.Domain.Account
{
    public class UserClaim: Entity
    {
        public User User { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}