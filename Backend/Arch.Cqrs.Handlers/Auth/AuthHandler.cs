using System.Security.Cryptography;
using System.Text;
using Arch.Cqrs.Client.Auth;
using Arch.CrossCutting.CqrsContracts;
using Arch.Domain.Account;
using Arch.Domain.Contracts;

namespace Arch.Cqrs.Handlers.Auth
{
    public class AuthHandler :
        ICommandHandler<Login, User>,
        ICommandHandler<Register>,
        IQueryHandler<UserExists, bool>
    {
        private readonly IAuthRepository _authRepository;
        public AuthHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public User Handle(Login command)
        {
            var user = _authRepository.Get(_ => _.Username== command.Username);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(command.Password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
           using(var hmac = new HMACSHA512(passwordSalt))
           {
               var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
               for(var i = 0; i < computerHash.Length; i++)
               {
                   if (computerHash[i] != passwordHash[i])
                        return false;
               }
           }
           return true;
        }

        public void Handle(Register command)
        {
           byte[] passwordHash, passwordSalt;
           CreatePasswordHash(command.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Username = command.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _authRepository.Add(user);
            _authRepository.Save();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using(var hmac = new HMACSHA512())
           {
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
           }
        }

        public bool Handle(UserExists query) =>
             _authRepository.Any(_ => _.Username == query.UserName);
    }
}