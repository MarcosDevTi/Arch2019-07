namespace Arch.CrossCutting.CqrsContracts
{
    public interface ICommandHandler<in TCommand>
        where TCommand: ICommand
    {
         void Handle(TCommand command);
    }
    public interface ICommandHandlerTo<in TCommand, TEntity>
        where TCommand: ICommand
    {
         void Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult>
        where TCommand: ICommand
    {
         TResult Handle(TCommand command);
    }

    public interface ICreateCommand: ICommand
    {

    }

    public interface IUpdateCommand: ICommand
    {

    }
}