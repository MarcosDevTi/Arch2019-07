using System;
using Arch.CrossCutting.CqrsContracts;

namespace Arch.Infra.Data
{
    public class Processor : IProcessor
    {
        private readonly IServiceProvider _provider;
        public Processor(IServiceProvider provider) =>
            _provider = provider;

        public TResult Get<TResult>(IQuery<TResult> query) =>
            GetHandle(typeof(IQueryHandler<,>), query.GetType(), typeof(TResult))
            .Handle((dynamic)query);

        public void Send<TCommand>(TCommand command) where TCommand : ICommand =>
            GetHandle(typeof(ICommandHandler<>), command.GetType())
            .Handle(command);

        public TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand =>
            GetHandle(typeof(ICommandHandler<,>), command.GetType(), typeof(TResult))
                .Handle((dynamic)command);

        private dynamic GetHandle(Type handle, params Type[] types) =>
            _provider.GetService(handle.MakeGenericType(types));
    }
}