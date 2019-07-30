using Arch.CrossCutting.CqrsContracts;
using Arch.Domain.Contracts;
using Arch.Domain.Core;

namespace Arch.Cqrs.Handlers.Shared
{
    public class SharedHandler<T> :
        ICommandHandlerTo<ICreateCommand, T>,
        ICommandHandlerTo<IUpdateCommand, T> 
            where T: Entity
    {
        private readonly IRepository<T> _repository;
        public SharedHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Handle(ICreateCommand command)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(IUpdateCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}