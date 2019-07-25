using Arch.CrossCutting.CqrsContracts;

namespace Arch.Cqrs.Client.Auth
{
    public class Login: ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}