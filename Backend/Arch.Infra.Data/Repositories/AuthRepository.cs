using Arch.Domain.Account;
using Arch.Domain.Contracts;

namespace Arch.Infra.Data.Repositories
{
    public class AuthRepository: 
        Repository<User>, IAuthRepository
    {
          public AuthRepository(ArchContext context)
            :base(context) {}
    }
}