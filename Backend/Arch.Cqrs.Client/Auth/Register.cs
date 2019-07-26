using Arch.CrossCutting.CqrsContracts;

namespace Arch.Cqrs.Client.Auth
{
    public class Register: ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}