using Arch.CrossCutting.CqrsContracts;

namespace Arch.Cqrs.Client.Auth
{
    public class UserExists: IQuery<bool>
    {
        public UserExists(string username)
        {
            UserName = username;
        }
        public string UserName { get; set; }
    }
}