using Arch.CrossCutting.CqrsContracts;

namespace Arch.Cqrs.Client.Auth
{
    public class UserExists: IQuery<bool>
    {
        public string UserName { get; set; }
    }
}